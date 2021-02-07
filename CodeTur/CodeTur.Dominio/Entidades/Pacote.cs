using CodeTur.Comum.Entidades;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Dominio.Entidades
{
    public class Pacote : Entidade
    {
        //deixando visivel os comentarios somente nessa classe
        private readonly List<Comentario> _comentarios;

        public string Descricao { get; set; }

        //como n vamos trabalhar com set, fazer return
        public IReadOnlyCollection<Comentario> Comentarios{ get { return _comentarios.ToArray(); }}

        public void AdicionarComentario(Comentario comentario) 
        {
            //verifiicar se usuario ja tem um comentario no pacote
            //evitar spam
            if (_comentarios.Any(x => x.IdUsuario == comentario.IdUsuario))
                AddNotification("Comentarios", "Usuário já possui um comentário neste pacote");

            if (Valid)
            _comentarios.Add(comentario);
        }
    }
}
