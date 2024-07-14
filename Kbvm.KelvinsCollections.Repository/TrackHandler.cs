using Kbvm.KelvinsCollections.Models.Models;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository
{
	public class TrackHandler : ITrackHandler
	{
		public IEnumerable<TrackDto> GetTracks(string showNotes, string? artist = null)
		{
			List<TrackDto> dtos = [];
			if (string.IsNullOrWhiteSpace(showNotes))
				return dtos;

			string[] showNoteLines = showNotes.Split('\n');
			for (int i = 0; i < showNoteLines.Length; i++)
			{
				var curLine = showNoteLines[i];
				if (string.IsNullOrWhiteSpace(curLine))
					continue;

				var trackNum = i + 1;
				var hyphenPos = curLine.LastIndexOf('-');
				TrackDto trackDto;

				if (hyphenPos == -1)
				{
					if (curLine.StartsWith("Demented News"))
						trackDto = new TrackDto("Demented News With Whimsical Will", trackNum, "Whimsical Will");
					else
						trackDto = new TrackDto(curLine, trackNum, artist ?? "Unknown Artist");
				}
				else
				{
					trackDto = new TrackDto(
						name: curLine[..(hyphenPos - 1)].Trim(),
						trackNumber: trackNum,
						artist: curLine[(hyphenPos + 1)..].Trim());
				}

				dtos.Add(trackDto);
			}

			return dtos;
		}
	}
}
