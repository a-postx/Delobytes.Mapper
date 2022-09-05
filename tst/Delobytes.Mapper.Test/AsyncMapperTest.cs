using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xunit;

namespace Delobytes.Mapper.Test
{
    public class AsyncMapperTest
    {
        [Fact]
        public void Map_Null_ThrowsArgumentNullException()
        {
            AsyncMapper mapper = new AsyncMapper();

            Assert.ThrowsAsync<ArgumentNullException>("source", () => mapper.MapAsync(null));
        }

        [Fact]
        public async Task Map_ToNewObject_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            MapTo to = await mapper.MapAsync(new MapFrom() {Property = 1});

            Assert.Equal(1, to.Property);
        }

        [Fact]
        public async Task MapArray_Empty_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            MapTo[] to = await mapper.MapArrayAsync(new MapFrom[0]);

            Assert.IsType<MapTo[]>(to);
            Assert.Empty(to);
        }

        [Fact]
        public async Task MapArray_ToNewObject_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            MapTo[] to = await mapper.MapArrayAsync(
                new MapFrom[]
                {
                    new MapFrom() {Property = 1},
                    new MapFrom() {Property = 2}
                });

            Assert.IsType<MapTo[]>(to);
            Assert.Equal(2, to.Length);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }

        [Fact]
        public async Task MapTypedCollection_Empty_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            List<MapTo> to = await mapper.MapCollectionAsync(
                new MapFrom[0],
                new List<MapTo>());

            Assert.IsType<List<MapTo>>(to);
            Assert.Empty(to);
        }

        [Fact]
        public async Task MapTypedCollection_ToNewObject_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            List<MapTo> to = await mapper.MapCollectionAsync(
                new MapFrom[]
                {
                    new MapFrom() {Property = 1},
                    new MapFrom() {Property = 2}
                },
                new List<MapTo>());

            Assert.IsType<List<MapTo>>(to);
            Assert.Equal(2, to.Count);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }

        [Fact]
        public async Task MapCollection_Empty_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            Collection<MapTo> to = await mapper.MapCollectionAsync(new MapFrom[0]);

            Assert.IsType<Collection<MapTo>>(to);
            Assert.Empty(to);
        }

        [Fact]
        public async Task MapCollection_ToNewObject_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            Collection<MapTo> to = await mapper.MapCollectionAsync(
                new MapFrom[]
                {
                    new MapFrom() {Property = 1},
                    new MapFrom() {Property = 2}
                });

            Assert.IsType<Collection<MapTo>>(to);
            Assert.Equal(2, to.Count);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }

        [Fact]
        public async Task MapList_Empty_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            List<MapTo> to = await mapper.MapListAsync(
                new MapFrom[0]);

            Assert.IsType<List<MapTo>>(to);
            Assert.Empty(to);
        }

        [Fact]
        public async Task MapList_ToNewObject_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            List<MapTo> to = await mapper.MapListAsync(
                new MapFrom[]
                {
                    new MapFrom() {Property = 1},
                    new MapFrom() {Property = 2}
                });

            Assert.IsType<List<MapTo>>(to);
            Assert.Equal(2, to.Count);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }

        [Fact]
        public async Task MapObservableCollection_Empty_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            ObservableCollection<MapTo> to = await mapper.MapObservableCollectionAsync(new MapFrom[0]);

            Assert.IsType<ObservableCollection<MapTo>>(to);
            Assert.Empty(to);
        }

        [Fact]
        public async Task MapObservableCollection_ToNewObject_Mapped()
        {
            AsyncMapper mapper = new AsyncMapper();

            ObservableCollection<MapTo> to = await mapper.MapObservableCollectionAsync(
                new MapFrom[]
                {
                    new MapFrom() {Property = 1},
                    new MapFrom() {Property = 2}
                });

            Assert.IsType<ObservableCollection<MapTo>>(to);
            Assert.Equal(2, to.Count);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }
    }
}