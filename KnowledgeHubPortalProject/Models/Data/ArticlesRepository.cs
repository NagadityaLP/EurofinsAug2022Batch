using KnowledgeHubPortalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortalProject.Models.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        private KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        public void Approve(List<int> articleIds)
        {
            //TODO : need to optimize the logic
            foreach (var aid in articleIds)
            {
                var article = db.Articles.Find(aid);
                if (article != null)
                    article.IsApproved = true;
            }
            db.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            return db.Articles.Find(id);
        }

        //return approved articles
        public List<Article> GetArticlesForBrowse()
        {
            return db.Articles.Where(a => a.IsApproved).ToList();
        }
        //return non-approved articles
        public List<Article> GetArticlesForReview()
        {
            return db.Articles.Where(a => !a.IsApproved).ToList();
        }

        public void Reject(List<int> articleIds)
        {
            foreach (var aid in articleIds)
            {
                var article = db.Articles.Find(aid);
                if (article != null)
                    db.Articles.Remove(article);
            }
            db.SaveChanges();
        }

        public List<Article> Search(string data)
        {
            throw new NotImplementedException();
        }

        public void Submit(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
    }
}