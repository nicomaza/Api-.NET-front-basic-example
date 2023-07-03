using _113918_mazavictornicolas.Data;
using _113918_mazavictornicolas.Dtos;
using _113918_mazavictornicolas.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _113918_mazavictornicolas.Bussines.Comand
{
    public class PostUsuario
    {


        public class PostUsuarioComand : IRequest<UserDto>
        {

            public string NombreUsuario { get; set; } = null!;

            public string Password { get; set; } = null!;

            public string rolNombre { get; set; } = null!;
        }

        public class PostUsuarioValidation : AbstractValidator<PostUsuarioComand>
        {
            public PostUsuarioValidation()
            {
                RuleFor(r => r.NombreUsuario).NotEmpty().WithMessage("ingese usuario");
                RuleFor(r => r.Password).NotEmpty().WithMessage("ingese password");
                RuleFor(r => r.rolNombre).NotEmpty().WithMessage("ingese rol");

            }
        }

        public class PostUsuarioHandler : IRequestHandler<PostUsuarioComand, UserDto>
        {
            private readonly PostUsuarioValidation _validation;
            private readonly Context _context;

            public PostUsuarioHandler(PostUsuarioValidation validation, Context context)
            {
                _validation = validation;
                _context = context;
            }
            public async Task<UserDto> Handle(PostUsuarioComand request, CancellationToken cancellationToken)
            {
                _validation.Validate(request);
                try
                {

                    var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdRol == 2 && u.NombreUsuario == request.NombreUsuario && u.Password == request.Password);

                    if (usuario != null)
                    {
                        UserDto userdto = new UserDto();
                        userdto.frase = "usuario existe";

                        userdto.code = System.Net.HttpStatusCode.OK;
                        userdto.mensage = "respuesta correcta";
                        userdto.exito = true;

                        return userdto;
                    }
                    throw new Exception("no existe usuario");



                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
