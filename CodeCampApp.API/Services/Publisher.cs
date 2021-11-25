using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCampApp.API.Services
{

    public class Publisher : IPublisher
    {
        public event EventHandler<CustomEvent> OnChange = delegate { };

        public void Notify(CustomEvent e)
        {
            OnChange(this, e);
        }
    }
}
