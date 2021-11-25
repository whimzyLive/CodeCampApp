using System;

namespace CodeCampApp.API.Services
{
    public interface IPublisher
    {
        event EventHandler<CustomEvent> OnChange;

        void Notify(CustomEvent e);
    }
}