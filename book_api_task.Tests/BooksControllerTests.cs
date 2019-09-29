using System;
using Xunit;
using book_api_task.Domain.Interfaces;
using book_api_task.Infrastructure.Data;
using book_api_task.Domain.Core;
using book_api_task.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace book_api_task.Tests
{  
    public class BooksControllerTests
    {
        BooksController _controller;
        IBookRepository _repository;

        public BooksControllerTests()
        {
            _repository = new BookRepository();
            _controller = new BooksController(_repository);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType(GetTestBooks().GetType(), okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Book>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(4);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get(2);

            // Assert
            Assert.IsType<ActionResult<Book>>(okResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            
            // Act
            var okResult = _controller.Get(2).Result as ObjectResult;

            // Assert
            Assert.IsType<Book>(okResult.Value);
            Assert.Equal(2, (okResult.Value as Book).Id);
        }

        [Fact]
        public void Post_ReturnsOkResult()
        {
            
            // Act
            var okResult = _controller.Post(new Book("Hello","Its me"));

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void Put_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Put(2,new Book("Hello", "World"));

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Delete_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Delete(2);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        private List<Book> GetTestBooks()
        {
            var Books = new List<Book>
            {
                new Book( "Delia Owens", "Where the Crawdads Sing"),
                new Book("Demi Moore", "Inside Out: A Memoir"),
                new Book("Raina Telgemeier", "Guts"),

        };
            return Books;
        }
    }
}
