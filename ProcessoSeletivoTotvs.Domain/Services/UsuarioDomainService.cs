using ProcessoSeletivoTotvs.Domain.Contracts.CrossCuttings.Cryptography;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Domain.Exceptions.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Services
{
    public class UsuarioDomainService : BaseDomainService<Usuario>, IUsuarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMD5Cryptoghaphy _mD5Cryptoghaphy;

        public UsuarioDomainService(IUnitOfWork unitOfWork, IMD5Cryptoghaphy mD5Cryptoghaphy) 
            : base(unitOfWork.UsuarioRepository)
        {
            _unitOfWork = unitOfWork;
            _mD5Cryptoghaphy = mD5Cryptoghaphy;
        }

        public override void Create(Usuario entity)
        {
            if (_unitOfWork.UsuarioRepository.GetByLogin
                (entity.Email) != null)
                throw new EmailDeveSerUnicoException(entity.Email);

            entity.Senha = _mD5Cryptoghaphy.Encrypt(entity.Senha);

            base.Create(entity);
        }

        public Usuario Get(string email, string senha)
        {
            #region Criptografar a senha do usuário

            senha = _mD5Cryptoghaphy.Encrypt(senha);

            #endregion

            return _unitOfWork.UsuarioRepository
                .GetByLoginAndPassword(email, senha);
        }

        public Usuario GetByLogin(string email)
        {
            return _unitOfWork.UsuarioRepository.GetByLogin(email);
        }

        public override List<Usuario> GetAll()
        {
            return base.GetAll();
        }


    }
}
