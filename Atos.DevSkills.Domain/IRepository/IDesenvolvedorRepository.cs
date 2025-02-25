﻿using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.Domain.IRepository
{
    public interface IDesenvolvedorRepository : IBaseRepository<Desenvolvedor>
    {
        Task<List<Desenvolvedor>> ListAllWithSkill();
        Task<List<Desenvolvedor>> ListAllBySkill(string skill);
        Task<bool> ExistByEmail(string email);
        Task<Desenvolvedor?> FindByIdWithSkills(int id);
        Task<bool> ExistsById(int id);
    }
}
