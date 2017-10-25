using Jambo.Domain.Exceptions;
using Jambo.Domain.Model.Schools;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Jambo.Producer.Infrastructure.DataAccess.Repositories.Schools
{
    public class SchoolReadOnlyRepository : ISchoolReadOnlyRepository
    {
        private readonly MongoContext _mongoContext;

        public SchoolReadOnlyRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<IEnumerable<School>> GetAllSchools()
        {
            return await _mongoContext.Schools.Find(e => true).ToListAsync();
        }

        public async Task<Child> GetChild(Guid schoolId, Guid childId)
        {
            School school = await _mongoContext.Schools.Find(e => e.Id == schoolId).SingleAsync();

            foreach (var child in school.GetChildren())
            {
                if (child.Id == childId)
                    return child;
            }

            throw new JamboException("Objeto não encontrado");
        }

        public async Task<Parent> GetParent(Guid schoolId, Guid parentId)
        {
            School school = await _mongoContext.Schools.Find(e => e.Id == schoolId).SingleAsync();

            foreach (var parent in school.GetParents())
            {
                if (parent.Id == parentId)
                    return parent;
            }

            throw new JamboException("Objeto não encontrado");
        }

        public async Task<School> GetSchool(Guid id)
        {
            return await _mongoContext.Schools.Find(e => e.Id == id).SingleAsync();
        }

        public async Task<Teacher> GetTeacher(Guid schoolId, Guid teacherId)
        {
            School school = await _mongoContext.Schools.Find(e => e.Id == schoolId).SingleAsync();

            foreach (var teacher in school.GetTeachers())
            {
                if (teacher.Id == teacherId)
                    return teacher;
            }

            throw new JamboException("Objeto não encontrado");
        }
    }
}
