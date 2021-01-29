using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using Xunit;

namespace CodeTur.Testes.Entidades
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetornarErroSeUsuarioForInvalido()
        {
            var usuario = new Usuario("", "", "", EnTipoUsuario.Admin );
            //testando com Assert (xUnit)
            Assert.True(usuario.Invalid, "Usuario é valido");
        }

        [Fact]
        public void DeveRetornarSucessoSeUsuarioForValido()
        {
            var usuario = new Usuario("Fernando Araujo", "fernandoa@senai.br", "senha12", EnTipoUsuario.Admin);
            usuario.AdicionarTelefone("(11) 921984021");

            //testando com Assert (xUnit)
            Assert.True(usuario.Valid, "Usuario é invalido");
        }

        public void Usuario()
        {    
        }
    }
}
