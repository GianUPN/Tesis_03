using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Tesis_02.Core
{
    // A delegate type for hooking up change notifications.
    public delegate void ChangedEventHandler(object sender, object e);

    // A class that works just like ArrayList, but sends event
    // notifications whenever the list changes.
    public class ListaInteligente : ArrayList
    {

        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public event ChangedEventHandler Changed;

        // Invoke the Changed event; called whenever list changes
        protected virtual void OnChanged(object e) 
        {
            if (Changed != null)
                Changed(this, e);
        }

      // Override some of the methods that can change the list;
      // invoke event after each
      public override int Add(object value) 
      {
         int i = base.Add(value);
         OnChanged(value);
         return i;
      }

      public override void Clear() 
      {
         base.Clear();
         OnChanged(EventArgs.Empty);
      }

      public override object this[int index] 
      {
         set 
         {
            base[index] = value;
            OnChanged(EventArgs.Empty);
         }
      }
   
    }
}
