﻿namespace StockSharp.Algo.Storages.Remote.Messages
{
	using System.Runtime.Serialization;

    using Ecng.Common;

    using StockSharp.Messages;

	/// <summary>
	/// Available data info request.
	/// </summary>
	public class AvailableDataRequestMessage : Message, ISecurityIdMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AvailableDataRequestMessage"/>.
		/// </summary>
		public AvailableDataRequestMessage()
			: base(ExtendedMessageTypes.AvailableDataRequest)
		{
		}

		/// <inheritdoc />
		[DataMember]
		public SecurityId SecurityId { get; set; }

		/// <inheritdoc />
		[DataMember]
		public DataType RequestDataType { get; set; }

		/// <inheritdoc />
		[DataMember]
		public StorageFormats Format { get; set; }

		/// <summary>
		/// Create a copy of <see cref="AvailableDataRequestMessage"/>.
		/// </summary>
		/// <returns>Copy.</returns>
		public override Message Clone()
		{
			var clone = new AvailableDataRequestMessage
			{
				SecurityId = SecurityId,
				Format = Format,
				RequestDataType = RequestDataType?.TypedClone(),
			};

			CopyTo(clone);
			return clone;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return base.ToString() + $",SecId={SecurityId},Fmt={Format}";
		}
	}
}