using KnowledgeHubPortalProject.Models.Entities;
using System;
using System.Collections.Generic;

namespace KnowledgeHubPortalProject.Models.Data
{
    public interface IArticlesRepository
    {
        void Submit(Article article);
        List<Article> Search(string data);
        Article GetArticle(int id);
        void Approve(List<int> articleIds);
        void Reject(List<int> articleIds); 
        List<Article> GetArticlesForReview(); // Return all articles which are not approved
        List<Article> GetArticlesForBrowse(); //Return all articles which are approved
    }
}
