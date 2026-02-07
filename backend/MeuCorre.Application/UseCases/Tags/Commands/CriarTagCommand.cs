using MediatR;
using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Tags.Commands
{
    public class CriarTagCommand : IRequest<(string, bool)>
    {

        [Required(ErrorMessage = "E necessário informar o id do usuário")]
        public required Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Nome da tag é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "E necessário informar a cor da tag")]
        public required string  cor { get; set; }
    }

    internal class CriarTagCommandHandler : IRequestHandler<CriarTagCommand, (string, bool)>
    {
       private readonly ITagRepository _tagRepository;
       public CriarTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<(string, bool)> Handle(CriarTagCommand request, CancellationToken cancellationToken)
        {
            var existe = await _tagRepository.NomeExisteParaUsuarioAsync(request.Nome, request.UsuarioId);

            if (existe)
            {
                return ("Você já cadastrou uma tag com este nome", false);
            }

            var tag = new Tag(request.UsuarioId, request.Nome, request.cor);

            await _tagRepository.AdicionarAsync(tag);

            return ("Tag criada com sucesso", true);
        }
    }
}
