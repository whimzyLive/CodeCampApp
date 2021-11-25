using System;

namespace CodeCampApp.API.Services
{
    public interface IPublisher
    {
        event Action OnChange;

        void Notify();
    }
}