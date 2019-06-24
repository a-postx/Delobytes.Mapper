using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Delobytes.Mapper.Test
{
    public class MapperTest
    {
        [Fact]
        public void Map_Null_ThrowsArgumentNullException()
        {
            Mapper mapper = new Mapper();

            Assert.Throws<ArgumentNullException>("source", () => mapper.Map(null));
        }

        [Fact]
        public void Map_ToNewObject_Mapped()
        {
            Mapper mapper = new Mapper();

            MapTo to = mapper.Map(new MapFrom() { Property = 1 });

            Assert.Equal(1, to.Property);
        }

        [Fact]
        public void MapArray_Empty_Mapped()
        {
            Mapper mapper = new Mapper();

            MapTo[] to = mapper.MapArray(new MapFrom[0]);

            Assert.IsType<MapTo[]>(to);
            Assert.Empty(to);
        }

        [Fact]
        public void MapArray_ToNewObject_Mapped()
        {
            Mapper mapper = new Mapper();

            MapTo[] to = mapper.MapArray(
                new MapFrom[]
                {
                    new MapFrom() { Property = 1 },
                    new MapFrom() { Property = 2 }
                });

            Assert.IsType<MapTo[]>(to);
            Assert.Equal(2, to.Length);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }

        [Fact]
        public void MapTypedCollection_Empty_Mapped()
        {
            Mapper mapper = new Mapper();

            List<MapTo> to = mapper.MapCollection(
                new MapFrom[0],
                new List<MapTo>());

            Assert.IsType<List<MapTo>>(to);
            Assert.Empty(to);
        }

        [Fact]
        public void MapTypedCollection_ToNewObject_Mapped()
        {
            Mapper mapper = new Mapper();

            List<MapTo> to = mapper.MapCollection(
                new MapFrom[]
                {
                    new MapFrom() { Property = 1 },
                    new MapFrom() { Property = 2 }
                },
                new List<MapTo>());

            Assert.IsType<List<MapTo>>(to);
            Assert.Equal(2, to.Count);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }

        [Fact]
        public void MapCollection_Empty_Mapped()
        {
            Mapper mapper = new Mapper();

            Collection<MapTo> to = mapper.MapCollection(new MapFrom[0]);

            Assert.IsType<Collection<MapTo>>(to);
            Assert.Empty(to);
        }

        [Fact]
        public void MapCollection_ToNewObject_Mapped()
        {
            Mapper mapper = new Mapper();

            Collection<MapTo> to = mapper.MapCollection(
                new MapFrom[]
                {
                    new MapFrom() { Property = 1 },
                    new MapFrom() { Property = 2 }
                });

            Assert.IsType<Collection<MapTo>>(to);
            Assert.Equal(2, to.Count);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }

        [Fact]
        public void MapList_Empty_Mapped()
        {
            Mapper mapper = new Mapper();

            List<MapTo> to = mapper.MapList(new MapFrom[0]);

            Assert.IsType<List<MapTo>>(to);
            Assert.Empty(to);
        }

        [Fact]
        public void MapList_ToNewObject_Mapped()
        {
            Mapper mapper = new Mapper();

            List<MapTo> to = mapper.MapList(
                new MapFrom[]
                {
                    new MapFrom() { Property = 1 },
                    new MapFrom() { Property = 2 }
                });

            Assert.IsType<List<MapTo>>(to);
            Assert.Equal(2, to.Count);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }

        [Fact]
        public void MapObservableCollection_Empty_Mapped()
        {
            Mapper mapper = new Mapper();

            ObservableCollection<MapTo> to = mapper.MapObservableCollection(new MapFrom[0]);

            Assert.IsType<ObservableCollection<MapTo>>(to);
            Assert.Empty(to);
        }

        [Fact]
        public void MapObservableCollection_ToNewObject_Mapped()
        {
            Mapper mapper = new Mapper();

            ObservableCollection<MapTo> to = mapper.MapObservableCollection(
                new MapFrom[]
                {
                    new MapFrom() { Property = 1 },
                    new MapFrom() { Property = 2 }
                });

            Assert.IsType<ObservableCollection<MapTo>>(to);
            Assert.Equal(2, to.Count);
            Assert.Equal(1, to[0].Property);
            Assert.Equal(2, to[1].Property);
        }
    }
}
