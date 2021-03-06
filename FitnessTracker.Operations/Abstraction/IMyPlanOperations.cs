﻿using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Exercises;
using FitnessTracker.DataModel.Plan;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IMyPlanOperations
    {
        ICollection<MyPlanModel> GetPlans(int currUserId);
        int CreatePlan(CreatePlanModel model, int currUserId);
        void AddExercise(PostExerciseModel model, int currUserId);
        void AddExercise(IList<PostExerciseModel> model, int currUserId);
        void UpdateExercise(UpdateExerciseModel model, int currUserId);
        void DeleteExercise(int planId, int ExerciseId, int currUserId);
        ICollection<RecommendedPlanModel> GetRecommends(string query);
        void ApplyToRecommend(int id, int userId);
        ICollection<MyPlanModel> GetMyRecommendedPlans(int userId);
        void Unfollow(int id, int currUserId);
    }
}