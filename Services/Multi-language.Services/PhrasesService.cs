﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multi_language.Models;
using Multi_language.Data;

namespace Multi_language.Services
{
    public class PhrasesService : IPhrasesService
    {
        private readonly IRepository<Phrases> phrases;
        private readonly IRepository<PhrasesContext> phrasesContext;

        public PhrasesService(IRepository<Phrases> phrases, IRepository<PhrasesContext> phrasesContext)
        {
            this.phrases = phrases;
            this.phrasesContext = phrasesContext;
        }

        public void Add(Phrases Phrase)
        {
            phrases.Add(Phrase);
            phrases.SaveChanges();

        }

        public void Delete(int id)
        {
            var phrase = phrases.GetById(id);
            phrases.Delete(phrase);
            phrases.SaveChanges();
        }

        public IQueryable<Phrases> GetAll()
        {
            return phrases.All();
        }
        public IQueryable<Phrases> GetAllByIdLanguage(int IdLanguage)
        {
            return phrases.All().Where(p => p.IdLanguage == IdLanguage);
        }


        public IQueryable<Phrases> GetAllByIdProject(int IdProject, string UserId)
        {
            return phrases.All().Where(pc => pc.PhraseContext.IdProject == IdProject);
        }


        public IQueryable<Phrases> GetAllByIdProjectAndIdContext(int IdProject, int IdContext)
        {
            return phrases.All().Where(pc => pc.PhraseContext.IdProject == IdProject && pc.IdPhraseContext == IdContext);
        }

        public Phrases GetById(int IdPhrase)
        {
            return phrases.GetById(IdPhrase);
        }


        public string GetTextPhrase(int IdPhraseContext, int IdLanguage)
        {
            var phrase = phrases.All().Where(
            p => p.IdPhraseContext == IdPhraseContext
            && p.IdLanguage == IdLanguage).FirstOrDefault();

            return (phrase != null)?phrase.PhraseText:"";
        }

        public void Update(Phrases Phrase)
        {
            phrases.Update(Phrase);
            phrases.SaveChanges();
        }
    }
}
