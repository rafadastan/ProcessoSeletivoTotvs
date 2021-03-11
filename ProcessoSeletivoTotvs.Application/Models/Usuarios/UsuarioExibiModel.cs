using ProcessoSeletivoTotvs.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.Models.Usuarios
{
    public class UsuarioExibiModel
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Created do usuário.")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Modified do usuário.")]
        public DateTime Modified { get; set; }

        [Required(ErrorMessage = "Por favor, informe o LastLogin do usuário.")]
        public DateTime LastLogin { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Perfis do usuário.")]
        public List<PerfilDTO> Perfis { get; set; }
    }
}
