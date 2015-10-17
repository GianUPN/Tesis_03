using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Tesis_02.Core
{
    public class TileMap
    {

        private static TileMap instance = null;

         private TileMap() { }

      
        /*
         * --------------------------------------------------------------------------------------
         *  Parámetros de ejecución
         * --------------------------------------------------------------------------------------
         *  Las variables a continuación deben ser modificadas de acuerdo 
         *  al tipo de comportamiento deseado. */

        private static readonly int TILE_SIZE = 32;
        private static readonly int TILE_SIZE_BITS = 5; // Math.pow(2, TILE_SIZE_BITS) == TILE_SIZE

        /* --------------------------------------------------------------------------------------
         *  Fin de Parámetros de ejecución
         * --------------------------------------------------------------------------------------
         * El código a continuación es código del núcleo del motor de 
         * videojuegos y se DESACONSEJA su modificación */

        public ListaInteligente spritesAtras { get; set; }
        public ListaInteligente sprites { get; set; }
        public ListaInteligente spritesAdelante { get; set; }
        private Texture2D[][] tilesSolid = null;
        private Texture2D[][] tilesTecho = null;
        private Texture2D[][] tilesFondo = null;
        private Texture2D[][] tilesSuper = null;
        public enum Scrolling { Sprite, Manual, Inicio, Fin }
        public Scrolling HorizontalScrolling { get; set; }
        public Scrolling VerticalScrolling { get; set; }
        public Texture2D ParallaxBackground { get; set; }
        public enum ParallaxBackgroundScrolling { Normal, Inicio, Fin }
        public ParallaxBackgroundScrolling ParallaxBackgroundHorizontalScrolling { get; set; }
        public ParallaxBackgroundScrolling ParallaxBackgroundVerticalScrolling { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        
        public String mapName{get;set;}
        private Game game;

        public iSpriteFactory spriteFactory { get; set; }

        public Sprite spriteScrolling {get; set;}
        public int posSpriteScrollingTileX { get; set; }
        public int posSpriteScrollingTileY { get; set; }

        private Point pointCache = new Point();
        public int ancho {get; private set;}
        public int alto {get; private set;}

        public static TileMap GetInstance
        {
           get{
                if (instance == null)
                {
                    instance = new TileMap(); 

                }
                return instance;
            }
        }
       
        public static TileMap Instance(Game game, String mapName, Sprite personajePrincipal, int posPersonajeTileX, int posPersonajeTileY)
        {

            if (instance == null)
            {
                instance = new TileMap(game, mapName,  personajePrincipal,  posPersonajeTileX,  posPersonajeTileY);

            }
            return instance;

        }
        public static TileMap InstanceTileMap(Game game, String mapName, Texture2D parallaxBackground, Sprite spriteScrolling, int posPersonajeTileX, int posPersonajeTileY)
        {

            if (instance == null)
            {
                instance = new TileMap( game,  mapName,  parallaxBackground,  spriteScrolling,  posPersonajeTileX,  posPersonajeTileY);

            }
            return instance;

        }

        public TileMap(Game game, String mapName)
        {
            this.game = game;
            spritesAtras = new ListaInteligente();
            spritesAtras.Changed += new ChangedEventHandler(spritesAtras_Changed);
            sprites = new ListaInteligente();
            sprites.Changed += new ChangedEventHandler(sprites_Changed);
            spritesAdelante = new ListaInteligente();
            spritesAdelante.Changed += new ChangedEventHandler(spritesAdelante_Changed);
            this.mapName = mapName;
            regenerarMapa();
        }

        public TileMap(Game game, String mapName, Sprite personajePrincipal, int posPersonajeTileX, int posPersonajeTileY) :
            this(game, mapName, null, personajePrincipal, posPersonajeTileX, posPersonajeTileY) { }

        public TileMap(Game game, String mapName, Texture2D parallaxBackground, Sprite spriteScrolling, int posPersonajeTileX, int posPersonajeTileY) : this(game, mapName)
        {
            this.ParallaxBackground = parallaxBackground;
            this.posSpriteScrollingTileX = posPersonajeTileX;
            this.posSpriteScrollingTileY = posPersonajeTileY;
            this.spriteScrolling = spriteScrolling;
            HorizontalScrolling = Scrolling.Sprite;
            VerticalScrolling = Scrolling.Sprite;
            ParallaxBackgroundHorizontalScrolling = ParallaxBackgroundScrolling.Normal;
            ParallaxBackgroundVerticalScrolling = ParallaxBackgroundScrolling.Normal;
            spriteScrolling.x = tilesAPixels(posSpriteScrollingTileX);
            spriteScrolling.y = tilesAPixels(posSpriteScrollingTileY);
            this.sprites.Add(spriteScrolling);
        }

        void spritesAdelante_Changed(object sender, object e)
        {
            if (e is Sprite)
            {
                Sprite objSprite = (Sprite)e;
                objSprite.escenarioActual = this;
            }
        }

        void sprites_Changed(object sender, object e)
        {
            if (e is Sprite)
            {
                Sprite objSprite = (Sprite)e;
                objSprite.escenarioActual = this;
            }
        }

        void spritesAtras_Changed(object sender, object e)
        {
            if (e is Sprite)
            {
                Sprite objSprite = (Sprite)e;
                objSprite.escenarioActual = this;
            }
        }

        public void regenerarMapa() {
            generarMapa();
            if (spriteScrolling != null)
            {
                spriteScrolling.x = tilesAPixels(posSpriteScrollingTileX);
                spriteScrolling.y = tilesAPixels(posSpriteScrollingTileY);
                this.sprites.Add(spriteScrolling);
            }
        }

        private void generarMapa()
        {
            try
            {
                List<List<String>> tiles = new List<List<String>>();
    
                // Lee las lineas de texto
                
                StreamReader reader = new StreamReader(mapName);
                //BufferedReader reader = new BufferedReader(new FileReader(filename));
                while (true)
                {
                    String linea = reader.ReadLine();
                    // no more lines to read
                    if (linea == null) 
                    {
                        reader.Close();
                        break;
                    }
    
                    // Agrega la linea, a menos que sea un comentario
                    String[] arr = new String[0];
                    List<String> tilesHorizontal = new List<String>();
                    if (!linea.StartsWith("#")) 
                    {
                        //Divide en cada coma y guarda los elementos en un arreglo de cadenas
                        arr = linea.Split(',');
                        ancho = Math.Max(ancho, arr.Length);
                        tilesHorizontal.AddRange(arr);
                    }
                    tiles.Add(tilesHorizontal);
                }
    
                this.alto = tiles.Count;
                tilesSolid = new Texture2D[this.ancho][];
                tilesTecho = new Texture2D[this.ancho][];
                tilesFondo = new Texture2D[this.ancho][];
                tilesSuper = new Texture2D[this.ancho][];
                for (int i =0; i<this.ancho; i++)
                {
                    tilesSolid[i] = new Texture2D[this.alto];
                    tilesTecho[i] = new Texture2D[this.alto];
                    tilesFondo[i] = new Texture2D[this.alto];
                    tilesSuper[i] = new Texture2D[this.alto];
                }
                sprites.Clear();
                spritesAtras.Clear();
                spritesAdelante.Clear();
    
                for (int y = 0; y < this.alto; y++)
                {
                    List<String> valores = tiles[y];
                    for (int x = 0; x < this.ancho; x++) 
                    {
                        String[] arrValor = new String[0];
                        try 
                        {
                            if (valores[x] != null && valores[x] != "")
                            {
                                arrValor = valores[x].Split('|');
                                foreach (String valor in arrValor)
                                {
                                    if (valor.Trim() != "")
                                    {
                                        String valorMinusculas = valor.ToLower();
                                        if (valorMinusculas.StartsWith("x") || valorMinusculas.StartsWith("y") || valorMinusculas.StartsWith("z")) 
                                        {
                                            String spriteName = valor.Substring(1).Trim();
                                            int index = spriteName.IndexOf("(");
                                            float yOffset = 0;
                                            float xOffset = 0;
                                            if (index != -1)
                                            {
                                                int init = index + 1;
                                                int end = spriteName.Length - index - 2;
                                                String config = spriteName.Substring(init, end).ToLower();
                                                spriteName = spriteName.Substring(0, index);
                                                while (config != "") {
                                                    config = config.Trim();
                                                    if (config.StartsWith("+"))
                                                    {
                                                        config = config.Substring(1);
                                                        // REVISAR!
                                                        String[] arr = config.Split('+');
                                                        String temp = arr[0];
                                                        arr = temp.Split('-');
                                                        temp = arr[0];
                                                        if (temp.StartsWith("y"))
                                                        {
                                                            yOffset += float.Parse(temp.Substring(1));
                                                        }
                                                        else if (temp.StartsWith("x"))
                                                        {
                                                            xOffset += float.Parse(temp.Substring(1));
                                                        }
                                                        config = config.Substring(temp.Length);
                                                    } else if (config.StartsWith("-"))
                                                    {
                                                        config = config.Substring(1);
                                                        String[] arr = config.Split('+');
                                                        String temp = arr[0];
                                                        arr = temp.Split('-');
                                                        temp = arr[0];
                                                        if (temp.StartsWith("y"))
                                                        {
                                                            yOffset -= float.Parse(temp.Substring(1));
                                                        } 
                                                        else if (temp.StartsWith("x"))
                                                        {
                                                            xOffset -= float.Parse(temp.Substring(1));
                                                        }
                                                        config = config.Substring(temp.Length);
                                                    }
                                                }
                                            }
                                            if (valorMinusculas.StartsWith("x")) 
                                            {
                                                //Sprites atras: Los que empiezan con x o X
                                                if (spriteFactory != null)
                                                {
                                                    Sprite objSprite = spriteFactory.obtenerSprite(spriteName);
                                                    objSprite.x = tilesAPixels(x) + xOffset;
                                                    objSprite.y = tilesAPixels(y) + yOffset;
                                                    spritesAtras.Add(objSprite);
                                                }
                                            }
                                            else if (valorMinusculas.StartsWith("y"))
                                            {
                                                //Sprites: Los que empiezan con y o Y
                                                if (spriteFactory != null)
                                                {
                                                    Sprite objSprite = spriteFactory.obtenerSprite(spriteName);
                                                    objSprite.x = tilesAPixels(x) + xOffset;
                                                    objSprite.y = tilesAPixels(y) + yOffset;
                                                    this.sprites.Add(objSprite);
                                                }
                                            } 
                                            else if (valorMinusculas.StartsWith("z"))
                                            {
                                                //Sprites adelante: Los que empiezan con z o Z
                                                if (spriteFactory != null)
                                                {
                                                    Sprite objSprite = spriteFactory.obtenerSprite(spriteName);
                                                    objSprite.x = tilesAPixels(x) + xOffset;
                                                    objSprite.y = tilesAPixels(y) + yOffset;
                                                    spritesAdelante.Add(objSprite);
                                                }
                                            }
                                        }
                                        else if (valorMinusculas.StartsWith("f"))
                                        {
                                            //Tiles Fondo: Los que empiezan con f o F
                                            tilesFondo[x][y] = game.Content.Load<Texture2D>("tiles/" + valor.Substring(1));
                                        }
                                        else if (valorMinusculas.StartsWith("t"))
                                        {
                                            //Tiles Techo: Los que empiezan con t o T
                                            tilesTecho[x][y] = game.Content.Load<Texture2D>("tiles/" + valor.Substring(1));
                                        } 
                                        else if (valorMinusculas.StartsWith("s"))
                                        {
                                            //Tiles Super: Los que empiezan con s o S
                                            tilesSuper[x][y] = game.Content.Load<Texture2D>("tiles/" + valor.Substring(1));
                                        } else if (valorMinusculas.StartsWith("a")) {
                                        } else if (valorMinusculas.StartsWith("d")) {
                                        }
                                        else
                                        {
                                            //Tiles Solidos: Los que empiezan con un numero
                                            //(Tiles por defecto)
                                            tilesSolid[x][y] = game.Content.Load<Texture2D>("tiles/" + valor);
                                        }
                                    }
                                }
                            }
                        } catch (Exception e) {}
                    }
                }
            } catch {}

            GC.Collect();
            GC.WaitForPendingFinalizers();
            
        }

        /*
         * Convierte una posicion en pixels position a una posicion en tiles.
         * Si no es potencia de 2, usar: (int)Math.floor((float)pixels / TILE_SIZE);
         */
        public static int pixelsATiles(float pixels)
        {
            return pixelsATiles((int)Math.Round(pixels));
        }
        public static int pixelsATiles(int pixels)
        {
            return pixels >> TILE_SIZE_BITS;
        }

        /* 
         * Convierte una posicion en tiles a una posicion en pixels.
         * Si no es potencia de 2, usar: numTiles * TILE_SIZE
         */
        public static int tilesAPixels(int numTiles)
        {
            return numTiles << TILE_SIZE_BITS;
        }

        public void actualizar(long tiempoTranscurrido)
        {
            for (int i = 0; i < spritesAtras.Count; i++)
            {
                ((Sprite)spritesAtras[i]).actualizar(tiempoTranscurrido);
            }

            int cantidad = sprites.Count;
            for (int i = 0; i < cantidad; i++)
            {
                actualizarColisiones(((Sprite)sprites[i]), tiempoTranscurrido);
                if (cantidad != sprites.Count)
                {
                    cantidad = sprites.Count;
                    i--;
                    continue;
                }
                ((Sprite)sprites[i]).actualizar(tiempoTranscurrido);
                if (cantidad != sprites.Count)
                {
                    cantidad = sprites.Count;
                    i--;
                }
            }
            
            for (int i = 0; i < spritesAdelante.Count; i++)
            {
                ((Sprite)spritesAdelante[i]).actualizar(tiempoTranscurrido);
            }
            
        }

        public void dibujar(SpriteBatch spriteBatch, int anchoPantalla, int altoPantalla)
        {
            //Horizontal Scrolling
            int anchoMapa = tilesAPixels(ancho);
            switch(HorizontalScrolling)
            {
                case Scrolling.Sprite:
                    // Obtener la posicion de scroll
                    // basados en la posicion del spriteScrolling
                    OffsetX = anchoPantalla / 2 
                        - ((int)Math.Round(spriteScrolling.x)) - TILE_SIZE;
                    OffsetX = Math.Min(OffsetX, 0);
                    OffsetX = Math.Max(OffsetX, anchoPantalla - anchoMapa);
                    break;
                case Scrolling.Inicio:
                    OffsetX = 0;
                    break;
                case Scrolling.Fin:
                    OffsetX = anchoPantalla - anchoMapa;
                    break;
            }

            //Vertical Scrolling
            int altoMapa = tilesAPixels(alto);
            switch (VerticalScrolling)
            {
                case Scrolling.Sprite:
                    // Obtener la posicion de scroll
                    // basados en la posicion del spriteScrolling
                    OffsetY = altoPantalla / 2
                        - ((int)Math.Round(spriteScrolling.y)) - TILE_SIZE;
                    OffsetY = Math.Min(OffsetY, 0);
                    OffsetY = Math.Max(OffsetY, altoPantalla - altoMapa);
                    break;
                case Scrolling.Inicio:
                    OffsetY = 0;
                    break;
                case Scrolling.Fin:
                    OffsetY = altoPantalla - altoMapa;
                    break;
            }

            // Dibuja el parallax background
            if (ParallaxBackground != null)
            {
                int x = 0;
                switch (ParallaxBackgroundHorizontalScrolling)
                {
                    case ParallaxBackgroundScrolling.Normal:
                        x = OffsetX
                        * (anchoPantalla - ParallaxBackground.Width)
                        / (anchoPantalla - anchoMapa);
                        break;
                    case ParallaxBackgroundScrolling.Fin:
                        x = anchoPantalla - ParallaxBackground.Width;
                        break;
                }

                int y = 0;
                switch (ParallaxBackgroundHorizontalScrolling)
                {
                    case ParallaxBackgroundScrolling.Normal:
                        y = OffsetY
                        * (altoPantalla - ParallaxBackground.Height)
                        / (altoPantalla - altoMapa);
                        break;
                    case ParallaxBackgroundScrolling.Fin:
                        y = altoPantalla - ParallaxBackground.Height;
                        break;
                }

                spriteBatch.Draw(ParallaxBackground, new Vector2(x, y), Color.White);
            }
    
            // dibuja los tiles visibles
            int primerTileX = pixelsATiles(-OffsetX);
            int ultimoTileX = primerTileX + pixelsATiles(anchoPantalla) + 1;
    
            for (int y = 0; y < alto; y++)
            {
                //for (int x = primerTileX; x <= ultimoTileX; x++)
                for (int x = primerTileX; x < ultimoTileX; x++)
                {
                    int posX = tilesAPixels(x) + OffsetX;
                    int posY = tilesAPixels(y) + OffsetY;
                    //dibuja los tiles del fondo
                    Texture2D image = null;
                    if (x < tilesFondo.Count() && y < tilesFondo[x].Count())
                    {
                        image = tilesFondo[x][y];
                    }
                    if (image != null)
                    {
                        spriteBatch.Draw(image, new Vector2(posX, posY), Color.White);
                    }
                    //dibuja los tiles solidos
                    //(los que se pisan y NO se pueden atravesar)
                    image = null;
                    if (x < tilesSolid.Count() && y < tilesSolid[x].Count())
                    {
                        image = tilesSolid[x][y];
                    }
                    if (image != null)
                    {
                        spriteBatch.Draw(image, new Vector2(posX, posY), Color.White);
                    }
                    //dibuja los tiles de techo
                    //(los que se pisan y SI se pueden atravesar)
                    image = null;
                    if (x < tilesTecho.Count() && y < tilesTecho[x].Count())
                    {
                        image = tilesTecho[x][y];
                    }
                    if (image != null)
                    {
                        spriteBatch.Draw(image, new Vector2(posX, posY), Color.White);
                    }
                }
            }
    
            // Dibuja a los sprites de atras
            for (int i = 0; i < spritesAtras.Count; i++)
            {
                Sprite objSprite = (Sprite)spritesAtras[i];
                if (objSprite.visible)
                {
                    int x = ((int)Math.Round(objSprite.x)) + OffsetX;
                    if (x >= 0 && x < anchoPantalla)
                    {
                        int y = ((int)Math.Round(objSprite.y)) + OffsetY;
                        spriteBatch.Draw(objSprite.animacion.obtenerImagen(), new Vector2(x, y), Color.White);
                    }
                }
            }   
            // Dibuja los sprites
            for (int i = 0; i < sprites.Count; i++)
            {
                Sprite objSprite = (Sprite)sprites[i];
                if (objSprite.visible)
                {
                    int x = ((int)Math.Round(objSprite.x)) + OffsetX;
                    if (x >= -200 && x < anchoPantalla)
                    {
                        int y = ((int)Math.Round(objSprite.y)) + OffsetY;
                        spriteBatch.Draw(objSprite.animacion.obtenerImagen(), new Vector2(x, y), Color.White);
                        //Esto es para que los enemigos "despierten"
                        //cuando estan dentro de la pantalla
                        if (objSprite is DespiertoPantalla)
                        {
                            ((DespiertoPantalla)objSprite).despierto = true;
                        }
                    }
                }
            }
            //Dibuja los sprites de adelante
            for (int i = 0; i < spritesAdelante.Count; i++) 
            {
                Sprite objSprite = (Sprite)spritesAdelante[i];
                if (objSprite.visible)
                {
                    int x = ((int)Math.Round(objSprite.x)) + OffsetX;
                    if (x >= 0 && x < anchoPantalla)
                    {
                        int y = ((int)Math.Round(objSprite.y)) + OffsetY;
                        spriteBatch.Draw(objSprite.animacion.obtenerImagen(), new Vector2(x, y), Color.White);
                    }
                }
            }
    
            for (int y = 0; y < alto; y++) 
            {
                //for (int x = primerTileX; x <= ultimoTileX; x++) 
                for (int x = primerTileX; x < ultimoTileX; x++)
                {
                    int posX = tilesAPixels(x) + OffsetX;
                    int posY = tilesAPixels(y) + OffsetY;
                    //dibuja los tiles superpuestos

                    Texture2D image = null;
                    if (x < tilesSuper.Count() && y < tilesSuper[x].Count())
                    {
                        image = tilesSuper[x][y];
                    }
                    if (image != null) 
                    {
                        spriteBatch.Draw(image, new Vector2(posX, posY), Color.White);
                    }
                }
            }
        }

        /*
        * Obtiene el tile con el que un Sprite colisiona.
        * 
        * Solo la posicion X o la posicion Y deben ser cambiadas,
        * pero nunca ambas al mismo tiempo.
        * 
        * El metodo retorna null si no se detecta una colision.
        */
        public Point? getColisionTile(Sprite sprite, float newX, float newY)
        {
            // Puntos a Pixeles
                float desdeX = Math.Min(sprite.x, newX);
                float desdeY = Math.Min(sprite.y, newY);
                float hastaX = Math.Max(sprite.x, newX);
                float hastaY = Math.Max(sprite.y, newY);
    
                // Pixeles a Tiles
                int desdeTileX = pixelsATiles(desdeX);
                int desdeTileY = pixelsATiles(desdeY);
                int hastaTileX = pixelsATiles(hastaX + sprite.animacion.obtenerImagen().Width - 1);
                int hastaTileY = pixelsATiles(hastaY + sprite.animacion.obtenerImagen().Height - 1);
    
                // check each tile for a collision
                for (int x = desdeTileX; x <= hastaTileX; x++)
                {
                    for (int y = desdeTileY; y <= hastaTileY; y++)
                    {
                        //Colision con Tiles de tipo solido
                        if (x < 0 || x >= ancho || y<0 || y >= alto || tilesSolid[x][y] != null)
                        {
                            // existe colision, retorna el punto
                            pointCache.X = x;
                            pointCache.Y = y;
                            return pointCache;
                        }
                        //Colision con Tiles de tipo techo
                        if (sprite.y < newY 
                                && (sprite.y + sprite.animacion.obtenerImagen().Height) <= (TileMap.tilesAPixels(y) + 8)
                                && tilesTecho[x][y] != null)
                        {
                            // existe colision, retorna el punto
                            pointCache.X = x;
                            pointCache.Y = y;
                            return pointCache;
                        }
                    }
                }
    
                // No se encontro colision
                return null;
         }

        public Sprite getColisionSprite(Sprite sprite, float x, float y) {
            if (sprite != null)
            {
                // Use the Rectangle's built-in intersect function to 
                // determine if two objects are overlapping
                Rectangle rectangle1;
                Rectangle rectangle2;
                

                // Only create the rectangle once for the player
                rectangle1 = new Rectangle(
                    (int)sprite.x,
                    (int)sprite.y,
                    sprite.animacion.obtenerImagen().Width,
                    sprite.animacion.obtenerImagen().Height);


                Sprite[] arrSprite = new Sprite[sprites.Count];
                arrSprite = Array.ConvertAll(sprites.ToArray(), item => (Sprite)item);

                foreach (Sprite otroSprite in arrSprite)
                {
                    if (otroSprite != null)
                    {
                        rectangle2 = new Rectangle(
                        (int)otroSprite.x,
                        (int)otroSprite.y,
                        otroSprite.animacion.obtenerImagen().Width,
                        otroSprite.animacion.obtenerImagen().Height);

                        if (sprite != otroSprite && rectangle1.Intersects(rectangle2))
                        {
                            // si existe colision, retorna el sprite
                            return otroSprite;
                        }
                    }
                }
            }
            // no collision found
            return null;
        }

         /*
         * Actualiza los sprites con las 
         * colisiones de los Tiles y 
         * otros Sprites.
         */
         private void actualizarColisiones(Sprite objSprite, long elapsedTime) {
            if (objSprite.solidoTiles) {
                // Corregir x
                float dx = objSprite.velocidadX;
                float oldX = objSprite.x;
                float newX = oldX + dx * elapsedTime;
                Point? tile = getColisionTile(objSprite, newX, objSprite.y);
                if (tile != null) {
                    // line up with the tile boundary
                    if (dx > 0) {
                        objSprite.x = 
                                TileMap.tilesAPixels(tile.Value.X)
                                - objSprite.animacion.obtenerImagen().Width
                                - (objSprite.x - objSprite.x);
                    } else if (dx < 0) {
                        objSprite.x = TileMap.tilesAPixels(tile.Value.X + 1);
                    }
                    objSprite.evento_ColisionHorizontalTile();
                }
    
                // Corregir y
                float dy = objSprite.velocidadY;
                float oldY = objSprite.y;
                float newY = oldY + dy * elapsedTime;
                tile = getColisionTile(objSprite, objSprite.x, newY);
                if (tile != null) {
                    // line up with the tile boundary
                    if (dy > 0) {
                        objSprite.y = TileMap.tilesAPixels(tile.Value.Y)
                                        - objSprite.animacion.obtenerImagen().Height;
                    } else if (dy < 0) {
                        objSprite.y = TileMap.tilesAPixels(tile.Value.Y + 1);
                    }
                    objSprite.evento_ColisionVerticalTile();
                }
            }

            //if (objSprite.solidoSprites || objSprite is BoxCollisionSprite) {
            if (objSprite.solidoSprites)
            {
                //Colision Horizontal Sprites
                float dx = objSprite.velocidadX;
                float oldX = objSprite.x;
                float newX = oldX + dx * elapsedTime;
                Sprite sprite = getColisionSprite(objSprite, newX, objSprite.y);
                if (sprite != null && sprite.solidoSprites) {
                    sprite.evento_ColisionHorizontalSprite(objSprite);
                }
                //Colision Vertical Sprites
                float dy = objSprite.velocidadY;
                float oldY = objSprite.y;
                float newY = oldY + dy * elapsedTime;
                sprite = getColisionSprite(objSprite, objSprite.x, newY);
                if (sprite != null && sprite.solidoSprites)
                {
                    sprite.evento_ColisionVerticalSprite(objSprite);
                }
            }
        }
    }
}