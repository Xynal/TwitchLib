﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchLib.Internal.TwitchAPI
{
    internal static class v3
    {
        public static class Blocks
        {
            public static Models.API.v3.Blocks.GetBlocksResponse GetBlocks(string channel, int limit = 25, int offset = 0)
            {
                string pm = $"?limit={limit}&offset={offset}";
                return Requests.Get<Models.API.v3.Blocks.GetBlocksResponse>($"https://api.twitch.tv/kraken/users/{channel}/blocks{pm}", Requests.API.v3);
            }

            public static Models.API.v3.Blocks.Block CreateBlock(string channel, string target)
            {
                return Requests.Put<Models.API.v3.Blocks.Block>($"https://api.twitch.tv/kraken/users/{channel}/blocks/{target}", Requests.API.v3);
            }

            public static void RemoveBlock(string channel, string target)
            {
                Requests.Delete($"https://api.twitch.tv/kraken/users/{channel}/blocks/{target}", Requests.API.v3);
            }
        }

        public static class ChannelFeed
        {
            public static Models.API.v3.ChannelFeeds.ChannelFeedResponse GetChannelFeedPosts(string channel, int limit = 25, string cursor = null)
            {
                string pm = $"?limit={limit}";
                if (cursor != null)
                    pm = $"{pm}&cursor={cursor}";
                return Requests.Get<Models.API.v3.ChannelFeeds.ChannelFeedResponse>($"https://api.twitch.tv/kraken/feed/{channel}/posts{pm}");
            }

            public static Models.API.v3.ChannelFeeds.PostResponse CreatePost(string channel, string content, bool share = false)
            {
                var model = new Models.API.v3.ChannelFeeds.CreatePostRequest()
                {
                    Content = content,
                    Share = share
                };
                return Requests.Post<Models.API.v3.ChannelFeeds.PostResponse>($"https://api.twitch.tv/kraken/feed/{channel}/posts", model, Requests.API.v3);
            }

            public static Models.API.v3.ChannelFeeds.Post GetPost(string channel, string postId)
            {
                return Requests.Get<Models.API.v3.ChannelFeeds.Post>($"https://api.twitch.tv/kraken/feed/{channel}/posts/{postId}", Requests.API.v3);
            }

            public static void DeletePost(string channel, string postId)
            {
                Requests.Delete($"https://api.twitch.tv/kraken/feed/{channel}/posts/{postId}", Requests.API.v3);
            }

            public static Models.API.v3.ChannelFeeds.PostReactionResponse CreateReaction(string channel, string postId, string emoteId)
            {
                return Requests.Post<Models.API.v3.ChannelFeeds.PostReactionResponse>($"https://api.twitch.tv/kraken/feed/{channel}/posts/{postId}/reactions?emote_id={emoteId}", null, Requests.API.v3);
            }

            public static void RemoveReaction(string channel, string postId, string emoteId)
            {
                Requests.Delete($"https://api.twitch.tv/kraken/feed/{channel}/posts/{postId}/reactions?emote_id={emoteId}", Requests.API.v3);
            }
        }

        /*public static class Channels
        {
            public static Models.API.v3.Channels.Channel GetChannel(string channel)
            {

            }

            public static Models.API.v3.Channels.Channel GetChannel(string token = null)
            {

            }

            public static List<Models.API.v3.Users.User> GetChannelEditors(string channel, string token = null)
            {

            }

            public static Models.API.v3.Users.User UpdateChannel(string channel, string status = null, string game = null, string delay = null, bool? channelFeedEnabled = null, string token = null)
            {

            }

            public static Models.API.v3.Users.User ResetStreamKey(string channel, string token = null)
            {

            }

            public static void RunCommercial(string channel, int length = 30, string token = null)
            {

            }

            public static Models.API.v3.Teams.Team GetTeams(string channel)
            {

            }
        }

        public static class Chat
        {
            public static Models.API.v3.Chat.BadgesResponse GetBadges(string channel)
            {

            }

            public static List<Models.API.v3.Chat.Emoticon> GetEmoticons()
            {

            }

            public static List<Models.API.v3.Chat.EmoticonImage> GetEmoticonImages(string emotesets = null)
            {

            }
        }

        public static class Follows
        {
            public static Models.API.v3.Follows.FollowersResponse GetFollowers(string channel, int limit = 25, int offset = 0, string cursor = "", Models.API.v3.Follows.Direction direction = Models.API.v3.Follows.Direction.Descending)
            {

            }

            public static Models.API.v3.Follows.FollowsResponse GetFollows(string channel, int limit = 25, int offset = 0, Models.API.v3.Follows.Direction direction = Models.API.v3.Follows.Direction.Descending, Models.API.v3.Follows.SortBy sortBy = Models.API.v3.Follows.SortBy.CreatedAt)
            {

            }

            public static Models.API.v3.Follows.Follows GetFollowsStatus(string channel, string targetChannel)
            {

            }

            public static Models.API.v3.Follows.Follows CreateFollow(string channel, string targetChannel, bool notifications = false, string token = null)
            {

            }

            public static void RemoveFollow(string channel, string target, string token = null)
            {

            }
        }

        public static class Games
        {
            public static Models.API.v3.Games.TopGamesResponse GetTopGames(int limit = 10, int offset = 0)
            {

            }
        }

        public static class Ingests
        {
            public static List<Models.API.v3.Ingests.Ingest> GetIngests()
            {

            }
        }

        public static class Root
        {
            public static Models.API.v3.Root.Token GetRoot(string token = null)
            {

            }
        }

        public static class Search
        {
            public static Models.API.v3.Search.SearchChannelsResponse SearchChannels(string query, int limit = 25, int offset = 0)
            {

            }

            public static Models.API.v3.Search.SearchStreamsResponse SearchStreams(string query, int limit = 25, int offset = 0, bool? hls = null)
            {

            }

            public static Models.API.v3.Search.SearchGamesResponse SearchGames(string query, Models.API.v3.Search.GameSearchType type, bool live = false)
            {

            }
        }

        public static class Streams
        {
            public static Models.API.v3.Streams.Stream GetStream(string channel)
            {

            }

            public static Models.API.v3.Streams.StreamsResponse GetStreams(string game = null, string channel = null, int limit = 25, int offset = 0, string clientId = null, Models.API.v3.Streams.StreamType streamType = Models.API.v3.Streams.StreamType.All, string language = "en")
            {

            }

            public static List<Models.API.v3.Streams.FeaturedStream> GetFeaturedStreams(int limit = 25, int offset = 0)
            {

            }

            public static Models.API.v3.Streams.Summary GetStreamsSummary(string game = null)
            {

            }
        }

        public static class Subscriptions
        {
            public static List<Models.API.v3.Subscriptions.SubscriptionsResponse> GetSubscriptions(string channel, int limit = 25, int offset = 0, Models.API.v3.Subscriptions.Direction direction = Models.API.v3.Subscriptions.Direction.Ascending, string token = null)
            {

            }

            public static List<Models.API.v3.Subscriptions.Subscription> GetAllSubscriptions(string channel, string token = null)
            {

            }

            public static bool ChannelHasUserSubscribed(string channel, string targetUser, string token = null)
            {

            }

            public static bool UserSubscribedToChannel(string user, string targetChannel, string token = null)
            {

            }
        }

        public static class Teams
        {
            public static List<Models.API.v3.Teams.Team> GetTeams(int limit = 25, int offset = 0)
            {

            }

            public static List<Models.API.v3.Teams.Team> GetTeam(string teamName)
            {

            }
        }

        public static class Users
        {
            public static Models.API.v3.Users.User GetUserFromUsername(string username)
            {

            }

            public static List<Models.API.v3.Users.EmoteSet> GetEmotes(string username, string token = null)
            {

            }

            public static Models.API.v3.Users.User GetUserFromToken(string token = null)
            {

            }
        }

        public static class Videos
        {
            public static Models.API.v3.Videos.Video GetVideo(string id)
            {

            }

            public static List<Models.API.v3.Videos.Video> GetTopVideos(int limit = 100, int offset = 0, string game = null, Models.API.v3.Videos.Period period = Models.API.v3.Videos.Period.Week)
            {

            }
        }*/
    }
}
