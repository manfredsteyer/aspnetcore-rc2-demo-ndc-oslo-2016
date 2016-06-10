using System.Collections.Generic;
using FlugDemo.Models;

namespace FlugDemo.Data
{
    public interface IFlightRepository
    {
        List<Flight> FindAll();
        Flight FindById(int id);
        List<Flight> FindByRoute(string von, string nach);
        void Save(Flight f);
    }
}