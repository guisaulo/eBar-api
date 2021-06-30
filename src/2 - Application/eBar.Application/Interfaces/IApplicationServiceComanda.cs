using System.Collections.Generic;
using eBar.Application.Dtos;

namespace eBar.Application.Interfaces
{
    public interface IApplicationServiceComanda
    {
        IEnumerable<ComandaDto> GetAll();
    }
}