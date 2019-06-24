using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Delobytes.Mapper
{
    /// <summary>
    /// <see cref="IMapper{TSource, TDestination}"/> extension methods.
    /// </summary>
    public static class MapperExtensions
    {
        /// <summary>
        /// Maps a specified source object to a new object of type <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source object type.</typeparam>
        /// <typeparam name="TDestination">Destination object type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source object.</param>
        /// <returns>Mapped object of type <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator" /> or <paramref name="source" /> is
        /// <c>null</c>.</exception>
        public static TDestination Map<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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
            translator.Map(source, destination);

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into array of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSourceCollection">Source collection type.</typeparam>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="sourceCollection">Source collection.</param>
        /// <param name="destinationCollection">Destination collection.</param>
        /// <returns>An array of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="sourceCollection"/> is
        /// <c>null</c>.</exception>
        public static TDestination[] MapArray<TSourceCollection, TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
            TSourceCollection sourceCollection,
            TDestination[] destinationCollection)
            where TSourceCollection : IEnumerable<TSource>
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (sourceCollection == null)
            {
                throw new ArgumentNullException(nameof(sourceCollection));
            }

            int i = 0;

            foreach (TSource item in sourceCollection)
            {
                TDestination destination = Factory<TDestination>.CreateInstance();
                translator.Map(item, destination);
                destinationCollection[i] = destination;
                ++i;
            }

            return destinationCollection;
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
        public static TDestination[] MapArray<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            TDestination[] destination = new TDestination[source.Count];

            for (int i = 0; i < source.Count; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination[i] = destinationItem;
            }

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into array of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Array of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static TDestination[] MapArray<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            TDestination[] destination = new TDestination[source.Count];

            for (int i = 0; i < source.Count; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination[i] = destinationItem;
            }

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
        public static TDestination[] MapArray<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            TDestination[] destination = new TDestination[source.Length];

            for (int i = 0; i < source.Length; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination[i] = destinationItem;
            }

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
        /// <returns>Array of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static TDestination[] MapArray<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            TDestination[] destination = new TDestination[source.Count()];
            int i = 0;

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination[i] = destinationItem;
                ++i;
            }

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
        /// <param name="sourceCollection">Source collection.</param>
        /// <param name="destinationCollection">Destination collection.</param>
        /// <returns>Collection of type <typeparamref name="TDestinationCollection"/> containing objects of type
        /// <typeparamref name="TDestination" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator" /> or <paramref name="sourceCollection" /> is
        /// <c>null</c>.</exception>
        public static TDestinationCollection MapCollection<TSourceCollection, TSource, TDestinationCollection,
            TDestination>(
            this IMapper<TSource, TDestination> translator,
            TSourceCollection sourceCollection,
            TDestinationCollection destinationCollection)
            where TSourceCollection : IEnumerable<TSource>
            where TDestinationCollection : ICollection<TDestination>
            where TDestination : new()
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }

            if (sourceCollection == null)
            {
                throw new ArgumentNullException(nameof(sourceCollection));
            }

            foreach (TSource item in sourceCollection)
            {
                TDestination destination = Factory<TDestination>.CreateInstance();
                translator.Map(item, destination);
                destinationCollection.Add(destination);
            }

            return destinationCollection;
        }

        /// <summary>
        /// Maps a list of <typeparamref name="TSource"/> into collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static Collection<TDestination> MapCollection<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            Collection<TDestination> destination = new Collection<TDestination>();

            for (int i = 0; i < source.Count; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static Collection<TDestination> MapCollection<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            Collection<TDestination> destination = new Collection<TDestination>();

            for (int i = 0; i < source.Count; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps an array of <typeparamref name="TSource"/> into collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static Collection<TDestination> MapCollection<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            Collection<TDestination> destination = new Collection<TDestination>();

            for (int i = 0; i < source.Length; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps the enumerable of <typeparamref name="TSource"/> into a collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static Collection<TDestination> MapCollection<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            Collection<TDestination> destination = new Collection<TDestination>();

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Add(destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps a list of <typeparamref name="TSource"/> into list of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>List of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static List<TDestination> MapList<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            List<TDestination> destination = new List<TDestination>(source.Count);

            for (int i = 0; i < source.Count; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into list of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>List of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static List<TDestination> MapList<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            List<TDestination> destination = new List<TDestination>(source.Count);

            for (int i = 0; i < source.Count; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps an array of <typeparamref name="TSource"/> into list of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>List of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static List<TDestination> MapList<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            List<TDestination> destination = new List<TDestination>(source.Length);

            for (int i = 0; i < source.Length; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps an enumerable of <typeparamref name="TSource"/> into list of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>List of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static List<TDestination> MapList<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            List<TDestination> destination = new List<TDestination>(source.Count());

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Add(destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps a list of <typeparamref name="TSource"/> into observable collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Observable collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static ObservableCollection<TDestination> MapObservableCollection<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            ObservableCollection<TDestination> destination = new ObservableCollection<TDestination>();

            for (int i = 0; i < source.Count; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps a collection of <typeparamref name="TSource"/> into observable collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Observable collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static ObservableCollection<TDestination> MapObservableCollection<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            ObservableCollection<TDestination> destination = new ObservableCollection<TDestination>();

            for (int i = 0; i < source.Count; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps an array of <typeparamref name="TSource"/> into observable collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Observable collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static ObservableCollection<TDestination> MapObservableCollection<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            ObservableCollection<TDestination> destination = new ObservableCollection<TDestination>();

            for (int i = 0; i < source.Length; ++i)
            {
                TSource sourceItem = source[i];
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Insert(i, destinationItem);
            }

            return destination;
        }

        /// <summary>
        /// Maps enumerable of <typeparamref name="TSource"/> into observable collection of
        /// <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source objects type.</typeparam>
        /// <typeparam name="TDestination">Destination objects type.</typeparam>
        /// <param name="translator">Translator.</param>
        /// <param name="source">Source objects.</param>
        /// <returns>Observable collection of <typeparamref name="TDestination"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="translator"/> or <paramref name="source"/> is
        /// <c>null</c>.</exception>
        public static ObservableCollection<TDestination> MapObservableCollection<TSource, TDestination>(
            this IMapper<TSource, TDestination> translator,
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

            ObservableCollection<TDestination> destination = new ObservableCollection<TDestination>();

            foreach (TSource sourceItem in source)
            {
                TDestination destinationItem = Factory<TDestination>.CreateInstance();
                translator.Map(sourceItem, destinationItem);
                destination.Add(destinationItem);
            }

            return destination;
        }
    }
}
