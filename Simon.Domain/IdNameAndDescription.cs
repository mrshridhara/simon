using System;

namespace Simon.Domain
{
	public abstract class IdNameAndDescription
	{
		protected IdNameAndDescription(Guid id, string name, string description)
		{
			this.Id = id;
			this.Name = name;
			this.Description = description;
		}

		public Guid Id { get; private set; }

		public string Name { get; private set; }

		public string Description { get; private set; }

		public bool ChangeName(string newName)
		{
			throw new System.NotImplementedException();
		}

		public bool ChangeDescription(string newDescription)
		{
			throw new System.NotImplementedException();
		}

		public void SetId(Guid id)
		{
			if (this.Id != Guid.Empty)
			{
				throw new ApplicationException("ID can be set only once per instance.");
			}

			this.Id = id;
		}
	}
}
