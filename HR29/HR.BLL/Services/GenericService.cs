using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using HR.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HR.BLL.Services
{
    public abstract class GenericService<EntityDTO, Entity, TKey> : IGenericService<EntityDTO, TKey>
       where EntityDTO : class, new() where Entity : class, new()
    {
        IGenericRepository<Entity, TKey> repository;
        private IMapper mapper;

        public GenericService(IGenericRepository<Entity, TKey> repository)
        {
            this.repository = repository;
            SetMapper();
        }
        protected virtual void SetMapper()
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.AddExpressionMapping();
                cfg.CreateMap<EntityDTO, Entity>();
                cfg.CreateMap<Entity, EntityDTO>();
            }).CreateMapper();
        }
        public EntityDTO Add(EntityDTO obj)
        {
            Entity item = mapper.Map<Entity>(obj);
            repository.Add(item);
            return mapper.Map<EntityDTO>(item);
        }

        public EntityDTO Delete(TKey id)
        {
            Entity good = repository.Get(id);
            repository.Delete(id);
            return mapper.Map<EntityDTO>(good);
        }

        public IEnumerable<EntityDTO> FindBy(Expression<Func<EntityDTO, bool>> predicate)
        {
            try
            {
                var predicateItem = mapper.Map<Expression<Func<Entity, bool>>>(predicate);
                return repository.FindBy(predicateItem)
                    .Select(c => mapper.Map<EntityDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EntityDTO Get(TKey id)
        {
            Entity item = repository.Get(id);
            return mapper.Map<EntityDTO>(item);
        }

        public IEnumerable<EntityDTO> GetAll()
        {
            return repository.GetAll().Select(i => mapper.Map<EntityDTO>(i));
        }

        public EntityDTO Update(EntityDTO obj)
        {
            Entity entity = mapper.Map<Entity>(obj);
            repository.Update(entity);
            return mapper.Map<EntityDTO>(entity);
        }
    }
}
