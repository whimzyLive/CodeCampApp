using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCampApp.API.Services
{
    public class Publisher : IPublisher
    {
        public event Action OnChange = delegate { };

        public void Notify()
        {
            OnChange?.Invoke();
        }
    }
}
