﻿using Application;
using Application.Dto;
using Application.Dto.Comment;
using Application.Dto.Comment.Book;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Domain.NoSQL;
using Domain.NoSQL.Entities;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.RDBMS;

namespace ApplicationTest.Services.Comment.Book
{
    [TestFixture]
    class RootServiceTest
    {
        private IBookRootCommentService _bookRootCommentService;
        private Mock<IRootRepository<BookRootComment>> _mockRootRepository;
        private Mock<IRepository<Domain.RDBMS.Entities.Book>> _bookRepositoryMock;
        private Mock<ICommentOwnerMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockRootRepository = new Mock<IRootRepository<BookRootComment>>();
            _mockMapper = new Mock<ICommentOwnerMapper>();
            _bookRepositoryMock = new Mock<IRepository<Domain.RDBMS.Entities.Book>>();
            _bookRootCommentService = new BookRootCommentService(_mockRootRepository.Object, _mockMapper.Object, _bookRepositoryMock.Object);
        }

        private IEnumerable<BookRootComment> GetTestCommentsEntities()
        {
            return new List<BookRootComment>()
            {
                new BookRootComment()
                {
                    Id="5e9c9ee859231a63bc853bf0",
                    Text="Text1",
                    Date=DateTime.UtcNow.ToString(),
                    BookId=1,
                    OwnerId=1,
                    Comments = new List<BookChildComment>()
                    {
                        new BookChildComment()
                        {
                            Id="5e9c9ee859231a63bc853bf1",
                            Text="Text2",
                            Date=DateTime.UtcNow.ToString(),
                            OwnerId = 2,
                            Comments = new List<BookChildComment>()
                        },
                        new BookChildComment()
                        {
                            Id="5e9c9ee859231a63bc853bf3",
                            Text="Text3",
                            Date=DateTime.UtcNow.ToString(),
                            OwnerId = 2,
                            Comments = new List<BookChildComment>()
                        }

                    }
                },
                new BookRootComment()
                {
                    Id="5e9c9ee859231a63bc853bf4",
                    Text="Text4",
                    Date=DateTime.UtcNow.ToString(),
                    BookId=2,
                    OwnerId = 2,
                    Comments=new List<BookChildComment>()
                },
                 new BookRootComment()
                {
                    Id="5e9c9ee859231a63bc853bf5",
                    Text="Text5",
                    Date=DateTime.UtcNow.ToString(),
                    BookId=1,
                    OwnerId = 2,
                    Comments=new List<BookChildComment>()
                }

            };
        }
        private IEnumerable<RootDto> GetTestCommentsDtos()
        {
            return new List<RootDto>()
            {
                new RootDto()
                {
                    Id="5e9c9ee859231a63bc853bf0",
                    Text="Text1",
                    Date=DateTime.UtcNow,
                    BookId=1,
                    Owner=new OwnerDto()
                    {
                        Id=1,
                        FirstName="A1",
                        MiddleName="B1",
                        LastName="C1",
                        Email="qwert@gmail.com",
                        Role="User"
                    },
                    Comments=new List<ChildDto>()
                    {
                        new ChildDto()
                        {
                            Id="5e9c9ee859231a63bc853bf1",
                            Text="Text2",
                            Date=DateTime.UtcNow,
                            Owner=new OwnerDto()
                            {
                                Id=1,
                                FirstName="A1",
                                MiddleName="B1",
                                LastName="C1",
                                Email="qwert1@gmail.com",
                                Role="User"
                            },
                            Comments = new List<ChildDto>()
                        },
                        new ChildDto()
                        {
                            Id="5e9c9ee859231a63bc853bf3",
                            Text="Text3",
                            Date=DateTime.UtcNow,
                            Owner=new OwnerDto()
                            {
                                Id=2,
                                FirstName="A2",
                                MiddleName="B2",
                                LastName="C2",
                                Email="qwert2@gmail.com",
                                Role="Admin"
                            },
                            Comments = new List<ChildDto>()
                        }

                    }
                },
                new RootDto()
                {
                    Id="5e9c9ee859231a63bc853bf4",
                    Text="Text4",
                    Date=DateTime.UtcNow,
                    BookId=2,
                    Owner=new OwnerDto()
                    {
                        Id=2,
                        FirstName="A2",
                        MiddleName="B2",
                        LastName="C2",
                        Email="qwert2@gmail.com",
                        Role="Admin"
                    },
                    Comments=new List<ChildDto>()
                },
                new RootDto()
                {
                    Id="5e9c9ee859231a63bc853bf5",
                    Text="Text5",
                    Date=DateTime.UtcNow,
                    BookId=1,
                    Owner=new OwnerDto()
                    {
                        Id=2,
                        FirstName="A2",
                        MiddleName="B2",
                        LastName="C2",
                        Email="qwert2@gmail.com",
                        Role="Admin"
                    },
                    Comments=new List<ChildDto>()
                }
            };
        }

        #region Update

        [Test]
        [TestCase(1, "5e9c9ee859231a63bc853bf0", 1)]
        [TestCase(0, null, 0)]
        public async Task UpdateComment_BookRootCommentExistsAndNot_ReturnsNumberOfUpdatedComments(int updateValue, string commentId, int expectedResult)
        {
            RootUpdateDto updateDto = new RootUpdateDto()
            {
                Id = "5e9c9ee859231a63bc853bf0"
            };
            _mockRootRepository
                .Setup(s => s.UpdateByIdAsync(updateDto.Id, It.IsAny<BookRootComment>()))
                .ReturnsAsync(new UpdateResult.Acknowledged(updateValue, updateValue, commentId));
            _mockRootRepository.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new BookRootComment());
            _bookRepositoryMock.Setup(x => x.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(new Domain.RDBMS.Entities.Book() { Id = 1232 });
            _mockRootRepository.Setup(x => x.GetAvgRatingAsync(It.IsAny<int>())).ReturnsAsync(1);
            _bookRepositoryMock.Setup(x => x.Update(It.IsAny<Domain.RDBMS.Entities.Book>(), new List<string>())).Returns(Task.CompletedTask);
            _bookRepositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var result = await _bookRootCommentService.Update(updateDto);

            result.Should().Be(expectedResult);
        }

        #endregion

        #region Remove

        [Test]
        [TestCase(1, "5e9c9ee859231a63bc853bf0", 1)]
        [TestCase(0, null, 0)]
        public async Task RemoveComment_BookRootCommentExistsAndNot_ReturnsNumberOfCommentsRemoved(int updateValue,string commentId, int expectedResult)
        {
            RootDeleteDto deleteDto = new RootDeleteDto()
            {
                Id = commentId
            };
            _mockRootRepository
                .Setup(s => s.DeleteByIdAsync(deleteDto.Id))
                .ReturnsAsync(new DeleteResult.Acknowledged(updateValue));
            _mockRootRepository.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new BookRootComment());
            _bookRepositoryMock.Setup(x => x.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(new Domain.RDBMS.Entities.Book() { Id = 1232 });
            _mockRootRepository.Setup(x => x.GetAvgRatingAsync(It.IsAny<int>())).ReturnsAsync(1);
            _bookRepositoryMock.Setup(x => x.Update(It.IsAny<Domain.RDBMS.Entities.Book>(), new List<string>())).Returns(Task.CompletedTask);
            _bookRepositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var result = await _bookRootCommentService.Remove(deleteDto.Id);

            result.Should().Be(expectedResult);
        }

        #endregion

        #region Add

        [Test]
        public async Task Add_BookRootComment_Returns_1()
        {
            RootInsertDto insertDto = new RootInsertDto();
            _mockRootRepository
                .Setup(s => s.InsertOneAsync(It.IsAny<BookRootComment>()))
                .ReturnsAsync(1);
            _bookRepositoryMock.Setup(x => x.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(new Domain.RDBMS.Entities.Book(){Id = 1232});
            _mockRootRepository.Setup(x => x.GetAvgRatingAsync(It.IsAny<int>())).ReturnsAsync(0);
            _bookRepositoryMock.Setup(x=>x.Update(It.IsAny<Domain.RDBMS.Entities.Book>(), new List<string>())).Returns(Task.CompletedTask);
            _bookRepositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var result = await _bookRootCommentService.Add(insertDto);

            result.Should().Be(1);
        }

        [Test]
        public async Task Add_BookRootComment_Returns_0()
        {
            RootInsertDto insertDto = new RootInsertDto();
            _mockRootRepository
                .Setup(s => s.InsertOneAsync(It.IsAny<BookRootComment>()))
                .ReturnsAsync(0);
            _bookRepositoryMock.Setup(x => x.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(new Domain.RDBMS.Entities.Book() { Id = 1232 });
            _mockRootRepository.Setup(x => x.GetAvgRatingAsync(It.IsAny<int>())).ReturnsAsync(1);
            _bookRepositoryMock.Setup(x => x.Update(It.IsAny<Domain.RDBMS.Entities.Book>(), new List<string>())).Returns(Task.CompletedTask);
            _bookRepositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var result = await _bookRootCommentService.Add(insertDto);

            result.Should().Be(0);
        }

        #endregion

        #region GetById

        [Test]
        [TestCase("5e9c9ee859231a63bc853bf0")]
        public async Task GetById_BookRootCommentExists_Returns_BookRootCommentDtoWithRequestedId(string id)
        {
            var expectedEntity = new BookRootComment() { Id = id };
            var expectedDto = new RootDto() { Id = id };
            _mockRootRepository.Setup(s => s.FindByIdAsync(id)).ReturnsAsync(expectedEntity);
            _mockMapper.Setup(s => s.MapAsync(expectedEntity)).ReturnsAsync(new RootDto() { Id = expectedDto.Id });

            var result = await _bookRootCommentService.GetById(id);

            result.Should().BeOfType<RootDto>();
            result.Id.Should().Be(id);
        }

        [Test]
        public async Task GetById_BookRootCommentNotExist_Returns_Null()
        {
            _mockRootRepository.Setup(s => s.FindByIdAsync("5e9c9ee859231a63bc853bf0")).ReturnsAsync(null as BookRootComment);
            _mockMapper.Setup(s => s.MapAsync(It.IsAny<BookRootComment>())).ReturnsAsync(null as RootDto);

            var result = await _bookRootCommentService.GetById("5e9c9ee859231a63bc853bf0");

            result.Should().BeNull();
        }

        #endregion

        #region GetByBookId

        [Test]
        [TestCase(1)]
        public async Task GetByBookId_BookRootCommentExists_Returns_BookRootCommentDtosWithRequestedBookId(int bookId)
        {
            IEnumerable<BookRootComment> expectedEntities = GetTestCommentsEntities().Where(x => x.BookId == bookId).ToList();
            IEnumerable<RootDto> expectedDtos = GetTestCommentsDtos().Where(x => x.BookId == bookId).ToList();

            _mockRootRepository.Setup(s => s.FindManyAsync(It.IsAny< Expression<Func<BookRootComment, bool>>>()))
                .ReturnsAsync(expectedEntities);
            _mockMapper.Setup(s => s.MapAsync(expectedEntities)).ReturnsAsync(expectedDtos);

            var result = await _bookRootCommentService.GetByBookId(bookId);

            result.Should().AllBeOfType<RootDto>();
            result.Should().HaveCount(expectedDtos.Count());
            result.Select(x => x.BookId).Should().AllBeEquivalentTo(bookId);
        }

        [Test]
        [TestCase(-1)]
        public async Task GetByBookId_BookRootCommentNotExists_Returns_EmptyIEnumerable(int bookId)
        {
            IEnumerable<BookRootComment> expectedEntities = GetTestCommentsEntities().Where(x => x.BookId == bookId).ToList();
            IEnumerable<RootDto> expectedDtos = GetTestCommentsDtos().Where(x => x.BookId == bookId).ToList();

            _mockRootRepository.Setup(s => s.FindManyAsync(It.IsAny<Expression<Func<BookRootComment, bool>>>()))
                .ReturnsAsync(expectedEntities);
            _mockMapper.Setup(s => s.MapAsync(expectedEntities)).ReturnsAsync(expectedDtos);

            var result = await _bookRootCommentService.GetByBookId(bookId);

            result.Should().AllBeOfType<RootDto>();
            result.Should().HaveCount(expectedDtos.Count());
        }

        #endregion

        #region GetAll

        [Test]
        public async Task GetAllBooks_BookRootCommentExists_Returns_BookRootCommentDtosWithRequestedBookId()
        {
            var expectedEntities = GetTestCommentsEntities();
            var expectedDtos = GetTestCommentsDtos();

            _mockRootRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(expectedEntities);
            _mockMapper.Setup(s => s.MapAsync(expectedEntities)).ReturnsAsync(expectedDtos);

            var result = await _bookRootCommentService.GetAll();

            result.Should().AllBeOfType<RootDto>();
            result.Should().HaveCount(expectedDtos.Count());
        }

        #endregion
    }
}
