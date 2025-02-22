﻿using AutoMapper;
using Moq;
using ReportingService.Application.Exceptions;
using ReportingService.Application.Mappings;
using ReportingService.Application.Services;
using ReportingService.Core;
using ReportingService.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.Application.Tests
{
    public class TransactionServiceTests
    {
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly Mapper _mapper;
        private readonly TransactionService _sut;

        public TransactionServiceTests()
        {
            _transactionRepositoryMock = new();
            _mapper = new(MapperHelper.ConfigureMapper());

            _sut = new(_transactionRepositoryMock.Object, _mapper);
        }
        
        [Fact]
        public async Task SearchTransaction_NonExistingUser_EntityNotFoundExceptionThrown()
        {
            var id = Guid.NewGuid();
            var msg = $"Customer {id} not found";
            var dates = new TransactionSearchFilter { DateFrom = DateTime.Now, DateTo = DateTime.Now };

            var ex = await Assert.ThrowsAsync<EntityNotFoundException>(() => _sut.SearchTransaction(id, dates));

            Assert.Equal(msg, ex.Message);
        }
    }
}
