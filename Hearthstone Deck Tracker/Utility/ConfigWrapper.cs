﻿#region

using System;
using System.Text.RegularExpressions;
using System.Windows;

#endregion

namespace Hearthstone_Deck_Tracker.Utility
{
	public class ConfigWrapper
	{
		public static bool ArenaStatsShowLegends
		{
			get { return Config.Instance.ArenaStatsShowLegends; }
			set
			{
				Config.Instance.ArenaStatsShowLegends = value;
				Config.Save();
			}
		}

		public static DateTime? ArenaStatsTimeFrameCustomStart
		{
			get { return Config.Instance.ArenaStatsTimeFrameCustomStart; }
			set
			{
				Config.Instance.ArenaStatsTimeFrameCustomStart = value;
				Config.Save();
			}
		}

		public static DateTime? ArenaStatsTimeFrameCustomEnd
		{
			get { return Config.Instance.ArenaStatsTimeFrameCustomEnd; }
			set
			{
				Config.Instance.ArenaStatsTimeFrameCustomEnd = value;
				Config.Save();
			}
		}

		public static bool ArenaStatsIncludeArchived
		{
			get { return Config.Instance.ArenaStatsIncludeArchived; }
			set
			{
				Config.Instance.ArenaStatsIncludeArchived = value;
				Config.Save();
			}
		}

		public static bool ArenaRewardDialog
		{
			get { return Config.Instance.ArenaRewardDialog; }
			set
			{
				Config.Instance.ArenaRewardDialog = value;
				Config.Save();
			}
		}

		public static int StatsWindowHeight
		{
			get { return Config.Instance.StatsWindowHeight; }
			set
			{
				Config.Instance.StatsWindowHeight = value;
				Config.Save();
			}
		}

		public static int StatsWindowWidth
		{
			get { return Config.Instance.StatsWindowWidth; }
			set
			{
				Config.Instance.StatsWindowWidth = value;
				Config.Save();
			}
		}

		public static bool ArenaSummaryChartsExpanded
		{
			get { return Config.Instance.ArenaSummaryChartsExpanded; }
			set
			{
				Config.Instance.ArenaSummaryChartsExpanded = value;
				Config.Save();
			}
		}

		public static bool ConstructedSummaryChartsExpanded
		{
			get { return Config.Instance.ConstructedSummaryChartsExpanded; }
			set
			{
				Config.Instance.ConstructedSummaryChartsExpanded = value;
				Config.Save();
			}
		}

		public static bool DeckPickerWildIncludesStandard
		{
			get { return Config.Instance.DeckPickerWildIncludesStandard; }
			set
			{
				Config.Instance.DeckPickerWildIncludesStandard = value;
				Config.Save();
			}
		}

		public static bool ConstructedStatsIncludeArchived
		{
			get { return Config.Instance.ConstructedStatsIncludeArchived; }
			set
			{
				Config.Instance.ConstructedStatsIncludeArchived = value;
				Config.Save();
			}
		}


		public static bool ConstructedStatsAsPercent
		{
			get { return Config.Instance.ConstructedStatsAsPercent; }
			set
			{
				Config.Instance.ConstructedStatsAsPercent = value;
				Config.Save();
			}
		}
		public static DateTime? ConstructedStatsTimeFrameCustomStart
		{
			get { return Config.Instance.ConstructedStatsTimeFrameCustomStart; }
			set
			{
				Config.Instance.ConstructedStatsTimeFrameCustomStart = value;
				Config.Save();
			}
		}

		public static DateTime? ConstructedStatsTimeFrameCustomEnd
		{
			get { return Config.Instance.ConstructedStatsTimeFrameCustomEnd; }
			set
			{
				Config.Instance.ConstructedStatsTimeFrameCustomEnd = value;
				Config.Save();
			}
		}

		public static bool StatsAutoRefresh
		{
			get { return Config.Instance.StatsAutoRefresh; }
			set
			{
				Config.Instance.StatsAutoRefresh = value;
				Config.Save();
			}
		}

		public static Visibility ShowLastPlayedDateOnDeckVisibility => Config.Instance.ShowLastPlayedDateOnDeck ? Visibility.Visible : Visibility.Collapsed;

		public static Visibility UseButtonVisiblity => Config.Instance.AutoUseDeck ? Visibility.Collapsed : Visibility.Visible;

		public static string ConstructedStatsRankFilterMin
		{
			get { return Config.Instance.ConstructedStatsRankFilterMin; }
			set
			{
				Config.Instance.ConstructedStatsRankFilterMin = ValidateRank(value);
				Config.Save();
			}
		}
		public static string ConstructedStatsRankFilterMax
		{
			get { return Config.Instance.ConstructedStatsRankFilterMax; }
			set
			{
				Config.Instance.ConstructedStatsRankFilterMax = ValidateRank(value);
				Config.Save();
			}
		}

		private static string ValidateRank(string value)
		{
			var match = Regex.Match(value, @"(?<legend>([lL]))?(?<rank>(\d+))");
			if(!match.Success)
				throw new ApplicationException("Invalid rank");
			var legend = match.Groups["legend"].Success;
			int rank;
			if(int.TryParse(match.Groups["rank"].Value, out rank))
			{
				if(!legend && rank > 25)
					throw new ApplicationException("Rank can not be higher than 25");
				if(rank < 1)
					throw new ApplicationException("Rank can not be lower than 1");
			}
			else
				throw new ApplicationException("Invalid rank");
			return (legend ? "L" : "") + rank;
		}
	}
}