using _113918_mazavictornicolas.Data;
using _113918_mazavictornicolas.Dtos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _113918_mazavictornicolas.Bussines.Queries
{
    public class GetAviones
    {
        public class GetAvionesQuery : IRequest<List<DtoAvion>>
        {

        }

        public class GetAvionesValidation : AbstractValidator<GetAvionesQuery>
        {

        }

        public class GetAvionesHandler : IRequestHandler<GetAvionesQuery, List<DtoAvion>>
        {
            private readonly Context _context;

            public GetAvionesHandler(Context context)
            {
                _context = context;
            }

            public async Task<List<DtoAvion>> Handle(GetAvionesQuery request, CancellationToken cancellationToken)
            {
                List<DtoAvion> listaAviones = new List<DtoAvion>();
                try
                {

                    if (request == null)
                    {
                       
                        throw new Exception("no hay aviones");
                    }
                    else
                    {
                        var aviones = await _context.Aviones.Include(i => i.IdFabricanteNavigation).Where(a => a.IdFabricanteNavigation.Nombre == "Boeing" || a.IdFabricanteNavigation.Nombre == "Airbus").ToListAsync();
                        foreach (var a in aviones)
                        {
                            DtoAvion dto = new DtoAvion();
                            dto.Id = a.Id;
                            dto.NombreFabricante = a.IdFabricanteNavigation.Nombre;
                            dto.CantidadAsientos = a.CantidadAsientos;
                            dto.Modelo = a.Modelo;
                            dto.CantidadMotores = a.CantidadMotores;
                            dto.DatosVarios = a.DatosVarios;

                            dto.code = System.Net.HttpStatusCode.OK;
                            dto.mensage = "respuesta correcta";
                            dto.exito = true;

                            listaAviones.Add(dto);

                        }

                        return listaAviones;
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
