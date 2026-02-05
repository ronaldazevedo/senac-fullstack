using MediatR;
using MeuCorre.Application.UseCases.Categorias.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Tags.Commands
{
    public class AtualizarTagCommand : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = "E necessário informar o id do usuário")]
        public required Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Nome da tag é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "E necessário informar a cor da tag")]
        public required string cor { get; set; }  
    }

    internal class AtualizarCategoriaCommandHandler : IRequestHandler<AtualizarCategoriaCommand, (string, bool)>
    {
        public Task<(string, bool)> Handle(AtualizarCategoriaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
