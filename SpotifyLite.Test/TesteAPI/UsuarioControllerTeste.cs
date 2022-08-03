using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpofityLite.Application.Account.Dto;
using SpofityLite.Application.Account.Handler.Query;
using SpofityLite.Application.Account.Service;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Handler.Query;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Api.Controllers;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.Repository;
using SpotifyLite.Domain.Account.ValueObject;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Domain.Album.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Test.TesteAPI
{
    public class UsuarioControllerTests
    {
        [Fact]
        public async Task DeveBuscarTodosUsuariosComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IUsuarioRepository> mockRepository = new Mock<IUsuarioRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            List<Musica> musicas = new List<Musica>()
            {
                new Musica(){ Nome = "Musica 1", Duracao = new Duracao(98) },
                new Musica(){ Nome = "Musica 2", Duracao = new Duracao(190) },
                new Musica(){ Nome = "Musica 3", Duracao = new Duracao(198) }
            };

            List<Playlist> playlist = new List<Playlist>() {
                new Playlist(){ Nome = "Playslist 1", Musicas = musicas }
            };

            List<Usuario> usuarios = new List<Usuario>()
            {
                new Usuario()
                {
                    Nome = "Usuario1",
                    Email = new Email("teste@teste.com"),
                    Password = new Password("123456"),
                    Playlists = playlist
                }
            };

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "TesteMusica1", "60"),
                new MusicaOutputDto(Guid.NewGuid(), "TesteMusica2", "120"),
                new MusicaOutputDto(Guid.NewGuid(), "TesteMusica3", "160")
            };

            List<PlaylistOutputDto> playlistOutputDto = new List<PlaylistOutputDto>() {
                new PlaylistOutputDto(Guid.NewGuid(), "Playslist 1", musicaOutputDto)
            };

            List<UsuarioOutputDto> usuarioOutputDto = new List<UsuarioOutputDto>()
            {
                new UsuarioOutputDto(Guid.NewGuid(), "Usuario1", new Email("teste@teste.com"), new Password("123456"), playlistOutputDto)
            };

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(usuarios.AsEnumerable());
            mockMapper.Setup(x => x.Map<List<UsuarioOutputDto>>(usuarios)).Returns(usuarioOutputDto);

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.ObterTodos();

            mockMediator.Setup(x => x.Send(It.IsAny<ObterTodosUsuarioQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ObterTodosUsuarioQueryResponse(result));

            var controller = new UsuarioController(mockMediator.Object);
            var resultController = controller.ObterTodos();

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as ObterTodosUsuarioQueryResponse;
            Assert.NotNull(response.Usuarios);

        }

        [Fact]
        public async Task DeveBuscarUsuarioPorIdComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IUsuarioRepository> mockRepository = new Mock<IUsuarioRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            var id = Guid.NewGuid();

            List<Musica> musicas = new List<Musica>()
            {
                new Musica(){ Nome = "TesteMusica1", Duracao = new Duracao(60) },
                new Musica(){ Nome = "TesteMusica2", Duracao = new Duracao(120) },
                new Musica(){ Nome = "TesteMusica3", Duracao = new Duracao(160) }
            };

            List<Playlist> playlist = new List<Playlist>() {
                new Playlist(){ Nome = "PlayslistTeste1", Musicas = musicas }
            };

            Usuario usuario = new Usuario()
            {
                Nome = "Usuario",
                Email = new Email("teste@teste.com"),
                Password = new Password("123456"),
                Playlists = playlist
            };

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "TesteMusica1", "60"),
                new MusicaOutputDto(Guid.NewGuid(), "TesteMusica2", "120"),
                new MusicaOutputDto(Guid.NewGuid(), "TesteMusica3", "160")
            };

            List<PlaylistOutputDto> playlistOutputDto = new List<PlaylistOutputDto>() {
                new PlaylistOutputDto(Guid.NewGuid(), "PlayslistTeste11", musicaOutputDto)
            };

            UsuarioOutputDto usuarioOutputDto = new UsuarioOutputDto(id, "Usuario", new Email("teste@teste.com"), new Password("123456"), playlistOutputDto);

            mockRepository.Setup(x => x.Get(id)).ReturnsAsync(usuario);
            mockMapper.Setup(x => x.Map<UsuarioOutputDto>(usuario)).Returns(usuarioOutputDto);

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.ObterPorId(id);

            mockMediator.Setup(x => x.Send(It.IsAny<ObterPorIdUsuarioQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ObterPorIdUsuarioQueryResponse(result));

            var controller = new UsuarioController(mockMediator.Object);
            var resultController = controller.ObterPorId(id);

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as ObterPorIdUsuarioQueryResponse;
            Assert.NotNull(response.Usuario);

        }
    }
}
