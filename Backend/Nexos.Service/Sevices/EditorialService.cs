using Nexos.Core.Entities;
using Nexos.Core.Exceptions;
using Nexos.Core.Interfaces;
using Nexos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Service.Sevices
{
    public class EditorialService : IEditorialService
    {
        private readonly IEditorialRepository EditorialRepository;

        public EditorialService(IEditorialRepository _EditorialRepository)
        {

            EditorialRepository = _EditorialRepository;


        }
        public async Task<Editorial> GetEditorial(int id)
        {
            try
            {
                return await EditorialRepository.GetEditorial(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Editorial>> GetEditorials()
        {
            try
            {
                return await EditorialRepository.GetEditorials();
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task InsertEditorial(Editorial model)
        {
            try
            {
                //Validation 
                if (model.MaxBook == null)
                    model.MaxBook = -1;

                await EditorialRepository.InsertEditorial(model);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }

        }
        public async Task<bool> UpdateEditorial(Editorial model)
        {
            try
            {
                return await EditorialRepository.UpdateEditorial(model);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
        public async Task<bool> DeleteEditorial(int id)
        {
            try
            {
                return await EditorialRepository.DeleteEditorial(id);
            }
            catch (Exception ex)
            {
                throw new GlobalException($"Excepción  no controlada debido a: {ex.Message}");
            }
        }
    }
}
