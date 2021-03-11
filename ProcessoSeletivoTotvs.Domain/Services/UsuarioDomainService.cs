using ProcessoSeletivoTotvs.Domain.Contracts.CrossCuttings.Cryptography;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories.UnitOfWork;
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
        private readonly IUnitOfWorkEntity _unitOfWorkEntity;
        private readonly IUnitOfWorkDapper _unitOfWorkDapper;
        private readonly IMD5Cryptoghaphy _mD5Cryptoghaphy;

        public UsuarioDomainService(IUnitOfWorkEntity unitOfWorkEntity, 
            IUnitOfWorkDapper unitOfWorkDapper, 
            IMD5Cryptoghaphy mD5Cryptoghaphy) 
            : base(unitOfWorkEntity.UsuarioRepositoryEntity, unitOfWorkDapper.UsuarioRepositoryDapper)
        {
            _unitOfWorkEntity = unitOfWorkEntity;
            _unitOfWorkDapper = unitOfWorkDapper;
            _mD5Cryptoghaphy = mD5Cryptoghaphy;
        }

        public override void Create(Usuario entity)
        {
            if (_unitOfWorkDapper.UsuarioRepositoryDapper.GetByLogin
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

            return _unitOfWorkDapper.UsuarioRepositoryDapper
                .GetByLoginAndPassword(email, senha);
        }

        public Usuario GetByLogin(string email)
        {
            return _unitOfWorkDapper.UsuarioRepositoryDapper.GetByLogin(email);
        }

        public override List<Usuario> GetAll()
        {
            return _unitOfWorkDapper.UsuarioRepositoryDapper.GetAllUsuario();
        }
    }
}
