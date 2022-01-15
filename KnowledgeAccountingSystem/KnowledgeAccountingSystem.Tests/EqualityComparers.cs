using BLL.Models;
using BLL.Models.Account;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace KnowledgeAccountingSystem.Tests
{
    internal class KnowledgeLevelEqualityComparer : IEqualityComparer<KnowledgeLevel>
    {
        public bool Equals([AllowNull] KnowledgeLevel x, [AllowNull] KnowledgeLevel y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Description == y.Description;
        }

        public int GetHashCode([DisallowNull] KnowledgeLevel obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class KnowledgeLevelModelEqualityComparer : IEqualityComparer<KnowledgeLevelModel>
    {
        public bool Equals([AllowNull] KnowledgeLevelModel x, [AllowNull] KnowledgeLevelModel y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Description == y.Description;
        }

        public int GetHashCode([DisallowNull] KnowledgeLevelModel obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class SkillCategoryEqualityComparer : IEqualityComparer<SkillCategory>
    {
        public bool Equals([AllowNull] SkillCategory x, [AllowNull] SkillCategory y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] SkillCategory obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class SkillCategoryModelEqualityComparer : IEqualityComparer<SkillCategoryModel>
    {
        public bool Equals([AllowNull] SkillCategoryModel x, [AllowNull] SkillCategoryModel y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] SkillCategoryModel obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class SkillEqualityComparer : IEqualityComparer<Skill>
    {
        public bool Equals([AllowNull] Skill x, [AllowNull] Skill y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Description == y.Description
                && x.CategoryId == y.CategoryId;
        }

        public int GetHashCode([DisallowNull] Skill obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class SkillModelEqualityComparer : IEqualityComparer<SkillModel>
    {
        public bool Equals([AllowNull] SkillModel x, [AllowNull] SkillModel y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Description == y.Description
                && x.CategoryId == y.CategoryId;
        }

        public int GetHashCode([DisallowNull] SkillModel obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class UserSkillEqualityComparer : IEqualityComparer<UserSkill>
    {
        public bool Equals([AllowNull] UserSkill x, [AllowNull] UserSkill y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.UserId == y.UserId
                && x.SkillId == y.SkillId
                && x.KnowledgeLevelId == y.KnowledgeLevelId;
        }

        public int GetHashCode([DisallowNull] UserSkill obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class UserSkillModelEqualityComparer : IEqualityComparer<UserSkillModel>
    {
        public bool Equals([AllowNull] UserSkillModel x, [AllowNull] UserSkillModel y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.SkillId == y.SkillId
                && x.KnowledgeLevelId == y.KnowledgeLevelId;
        }

        public int GetHashCode([DisallowNull] UserSkillModel obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals([AllowNull] User x, [AllowNull] User y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Email == y.Email;
        }

        public int GetHashCode([DisallowNull] User obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class UserModelEqualityComparer : IEqualityComparer<UserModel>
    {
        public bool Equals([AllowNull] UserModel x, [AllowNull] UserModel y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Email == y.Email;
        }

        public int GetHashCode([DisallowNull] UserModel obj)
        {
            return obj.GetHashCode();
        }
    }
}
