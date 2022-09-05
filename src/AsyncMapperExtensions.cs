using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Delobytes.Mapper
{
    /// <summary>
    /// <see cref="IAsyncMapper{TSource, TDestination}"/> extension methods.
    /// </summary>
    public static class AsyncMapperExtensions
    {
        /// <summary>
        /// Maps specified source object to a new object of type <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source object type.</typeparam>
        /// <typeparam name="TDestination">Destination object type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source object.</param>
        /// <returns>Mapped object of type <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator" /> or <paramref name="source" /> is
        /// <c>null</c>.</exception>
        public static async Task<TDestination> MapAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            TSource source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            TDestination destination = Factory<TDestination>.CreateInstance();
            await translator.MapAsync(source, destination);

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into array of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSourceCollection">Type of the source collection.</typeparam>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source collection.</param>
        /// <param name="destination">Destination collection.</param>
        /// <param name="sourceCount">Number of items in source collection.</param>
        /// <returns>Array of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<TDestination[]> MapArrayAsync<TSourceCollection, TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            TSourceCollection source,
            TDestination[] destination,
            int? sourceCount = null)
            where TSourceCollection : IEnumerable<TSource>
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            Task[] tasks = new Task[sourceCount ?? source.Count()];
            int i = 0;

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination[i] = destinationItem;
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);

                ++i;
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a list of <typeparamref name="TSource"/> into array of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Array of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<TDestination[]> MapArrayAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            List<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count;
            Task[] tasks = new Task[sourceCount];
            TDestination[] destination = new TDestination[sourceCount];
            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination[i] = destinationItem;
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into array of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects.</typeparam>
        /// <typeparam name="TDestination">Destination objects.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Array of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<TDestination[]> MapArrayAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            Collection<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count;
            Task[] tasks = new Task[sourceCount];
            TDestination[] destination = new TDestination[sourceCount];

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination[i] = destinationItem;
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps an array of <typeparamref name="TSource"/> into array of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Array of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<TDestination[]> MapArrayAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            TSource[] source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Length;
            Task[] tasks = new Task[sourceCount];
            TDestination[] destination = new TDestination[sourceCount];

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination[i] = destinationItem;
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps an enumerable of <typeparamref name="TSource"/> into array of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Aarray of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<TDestination[]> MapArrayAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            IEnumerable<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count();
            Task[] tasks = new Task[sourceCount];
            TDestination[] destination = new TDestination[sourceCount];
            int i = 0;

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination[i] = destinationItem;
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
                ++i;
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource" /> into collection of type
        /// <typeparamref name="TDestinationCollection" /> containing objects of type <typeparamref name="TDestination" />.
        /// </summary>
        /// <typeparam name="TSourceCollection">Source collection type.</typeparam>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestinationCollection">Destination collection type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source collection.</param>
        /// <param name="destination">Destination collection.</param>
        /// <returns>Collection of type <typeparamref name="TDestinationCollection"/> that contains objects of type
        /// <typeparamref name="TDestination" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator" /> or <paramref name="source" /> is
        /// <c>null</c>.</exception>
        public static async Task<TDestinationCollection> MapCollectionAsync<TSourceCollection, TSource, TDestinationCollection, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            TSourceCollection source,
            TDestinationCollection destination)
            where TSourceCollection : IEnumerable<TSource>
            where TDestinationCollection : ICollection<TDestination>
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            int sourceCount = source.Count();
            Task[] tasks = new Task[sourceCount];
            int i = 0;

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Add(destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
                ++i;
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a list of <typeparamref name="TSource"/> into collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<Collection<TDestination>> MapCollectionAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            List<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count;
            Task[] tasks = new Task[sourceCount];
            Collection<TDestination> destination = new Collection<TDestination>();

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<Collection<TDestination>> MapCollectionAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            Collection<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count;
            Task[] tasks = new Task[sourceCount];
            Collection<TDestination> destination = new Collection<TDestination>();

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps an array of <typeparamref name="TSource"/> into collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<Collection<TDestination>> MapCollectionAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            TSource[] source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Length;
            Task[] tasks = new Task[sourceCount];
            Collection<TDestination> destination = new Collection<TDestination>();

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps an enumerable of <typeparamref name="TSource"/> into collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<Collection<TDestination>> MapCollectionAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            IEnumerable<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count();
            Task[] tasks = new Task[sourceCount];
            Collection<TDestination> destination = new Collection<TDestination>();
            int i = 0;

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
                ++i;
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a list of <typeparamref name="TSource"/> into list of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>List of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<List<TDestination>> MapListAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            List<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count;
            Task[] tasks = new Task[sourceCount];
            List<TDestination> destination = new List<TDestination>(sourceCount);

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into list of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>List of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<List<TDestination>> MapListAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            Collection<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count;
            Task[] tasks = new Task[sourceCount];
            List<TDestination> destination = new List<TDestination>(sourceCount);

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps an array of <typeparamref name="TSource"/> into list of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>List of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<List<TDestination>> MapListAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            TSource[] source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Length;
            Task[] tasks = new Task[sourceCount];
            List<TDestination> destination = new List<TDestination>(sourceCount);

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps an enumerable of <typeparamref name="TSource"/> into list of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>List of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<List<TDestination>> MapListAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            IEnumerable<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count();
            Task[] tasks = new Task[sourceCount];
            List<TDestination> destination = new List<TDestination>(sourceCount);
            int i = 0;

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
                ++i;
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a list of <typeparamref name="TSource"/> into observable collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Observable collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<ObservableCollection<TDestination>> MapObservableCollectionAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            List<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count;
            Task[] tasks = new Task[sourceCount];
            ObservableCollection<TDestination> destination = new ObservableCollection<TDestination>();

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into observable collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Observable collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<ObservableCollection<TDestination>> MapObservableCollectionAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            Collection<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count;
            Task[] tasks = new Task[sourceCount];
            ObservableCollection<TDestination> destination = new ObservableCollection<TDestination>();

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps an array of <typeparamref name="TSource"/> into observable collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Observable collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<ObservableCollection<TDestination>> MapObservableCollectionAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            TSource[] source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Length;
            Task[] tasks = new Task[sourceCount];
            ObservableCollection<TDestination> destination = new ObservableCollection<TDestination>();

            for (int i = 0; i < sourceCount; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
            }

            await Task.WhenAll(tasks);

            return destination;
        }

        /// <summary>
        /// Maps an enumerable of <typeparamref name="TSource"/> into observable collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type</typeparam>
        /// <typeparam name="TDestination">Destination objects type</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Observable collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static async Task<ObservableCollection<TDestination>> MapObservableCollectionAsync<TSource, TDestination>(
            this IAsyncMapper<TSource, TDestination> translator,
            IEnumerable<TSource> source)
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int sourceCount = source.Count();
            Task[] tasks = new Task[sourceCount];
            ObservableCollection<TDestination> destination = new ObservableCollection<TDestination>();
            int i = 0;

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                destination.Insert(i, destinationItem);
                tasks[i] = translator.MapAsync(sourceItem, destinationItem);
                ++i;
            }

            await Task.WhenAll(tasks);

            return destination;
        }
    }
}
