using Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestions;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.SharedBusinessEntities;
using Sofa.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
	public class FieldQuestion : Entity<Guid>
	{
		private FieldQuestion()
		{
			_questionChoices = new List<FieldQuestionChoice>();
			//_coursePlacementQuestions = new List<CoursePlacementQuestion>();
		}
		private FieldQuestion(Guid id, string title, string content, LevelEnum level, QuestionTypeEnum questionType, Guid fieldId) : this()
		{
			AssignId(id);
			AssignTitle(title);
			AssignContent(content);
			AssignLevel(level);
			AssignType(questionType);
			AssignField(fieldId);
		}

		public Title Title { get; private set; }
		public Content Content { get; private set; }
		public Level Level { get; private set; }
		public QuestionType Type { get; private set; }

		public Guid FieldId { get; private set; }
		public Field Field { get; private set; }
		
		public IReadOnlyCollection<FieldQuestionChoice> QuestionChoices => _questionChoices.AsReadOnly();
		private readonly List<FieldQuestionChoice> _questionChoices;
		//public IReadOnlyCollection<CoursePlacementQuestion> CoursePlacementQuestions => _coursePlacementQuestions.AsReadOnly();
		//private readonly List<CoursePlacementQuestion> _coursePlacementQuestions;
		
		private void AssignTitle(string title) { this.Title = title; }
		private void AssignContent(string content) { this.Content = content; }
		private void AssignLevel(LevelEnum level) { this.Level = level; }
		private void AssignType(QuestionTypeEnum type) { this.Type = type; }
		private void AssignField(Guid fieldId) { this.FieldId = fieldId; }

		public static FieldQuestion CreateInstance(Guid id, string title, string content, LevelEnum level, QuestionTypeEnum questionType, Guid fieldId, Guid instituteId)
		{
			var instance = new FieldQuestion(id, title, content, level, questionType, fieldId);

			instance.AddDomainEvent(new AddFieldQuestionDomainEvent(id, title, content, level, questionType, fieldId, instituteId));

			return instance;
		}
		public void Delete(Guid fieldId, Guid instituteId)
		{
			MarkAsDeleted();

			this.AddDomainEvent(new DeleteFieldQuestionDomainEvent(this.Id, fieldId, instituteId));
		}
		public void Update(string title, string content, LevelEnum level, QuestionTypeEnum questionType, Guid fieldId, Guid instituteId)
		{
			AssignContent(content);
			AssignLevel(level);
			AssignType(questionType);
			AssignField(fieldId);
			base.MarkAsUpdated();

			this.AddDomainEvent(new UpdateFieldQuestionDomainEvent(Id, title, content, level, questionType, fieldId, instituteId));
		}
		public void AddChoice(FieldQuestionChoice choice)
		{
			_questionChoices.Add(choice);
		}
		public void DeleteChoice(FieldQuestionChoice choice) 
		{
			_questionChoices.Remove(choice);
		}
	}
}
