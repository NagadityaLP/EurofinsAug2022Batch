using KnowledgeHubPortalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortalProject.Models.Data
{
    public class DummyArticleRepo : IArticlesRepository
    {
        public void Approve(List<int> articleIds)
        {
            throw new NotImplementedException();
        }

        public Article GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesForBrowse()
        {
            List<Article> articles = new List<Article>
            {
                new Article { ArticleID = 111, Title = "dummy1", Url = "dummyurl1"},
                new Article { ArticleID = 222, Title = "dummy2", Url = "dummyurl2"},
                new Article { ArticleID = 333, Title = "dummy3", Url = "dummyurl3"},
                new Article { ArticleID = 444, Title = "dummy4", Url = "dummyurl4"}
            };
            return articles;
        }

        public List<Article> GetArticlesForReview()
        {
            throw new NotImplementedException();
        }

        public void Reject(List<int> articleIds)
        {
            throw new NotImplementedException();
        }

        public List<Article> Search(string data)
        {
            throw new NotImplementedException();
        }

        public void Submit(Article article)
        {
            throw new NotImplementedException();
        }
    }
}