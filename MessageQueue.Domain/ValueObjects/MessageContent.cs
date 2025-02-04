using MessageQueue.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Domain.ValueObjects
{
    /// <summary>
    /// Objeto de valor que contiene el contenido de un mensaje
    /// </summary>
    public sealed class MessageContent : ValueObject
    {
        /// <summary>
        /// Título del mensaje
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Contenido del mensaje
        /// </summary>
        public string Content { get; init; }

        /// <summary>
        /// Constructor para crear contenido 
        /// </summary>
        public MessageContent(){ }


        /// <summary>
        /// Constructor para crear contenido de mensaje válido
        /// </summary>
        /// <param name="title">Título no nulo</param>
        /// <param name="content">Contenido no nulo</param>
        public MessageContent(string title, string content)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        /// <summary>
        /// Componentes para igualdad: Título + Contenido
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
            yield return Content;
        }
    }
}
