﻿using Librarian.DAL.Entities;
using Librarian.Interfaces;
using Librarian.Services.Interfaces;
using Swftx.Wpf.Commands;
using Swftx.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Librarian.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly ITradingService _tradingService;
        private readonly IUserDialogService _dialogService;
        private readonly IRepository<Product> _booksRepository;
        private readonly IRepository<Category> _categoriesRepository;
        private readonly IRepository<Employee> _sellersRepository;
        private readonly IRepository<Customer> _buyersRepository;
        private readonly IRepository<Order> _transactionsRepository;

        #region Properties

        #region Tilte
        private string? _Title = "Librarian";

        /// <summary>
        /// Window title
        /// </summary>
        public string? Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        #region CurrentViewModel
        private ViewModel? _CurrentViewModel;

        /// <summary>
        /// Current ViewModel
        /// </summary>
        public ViewModel? CurrentViewModel { get => _CurrentViewModel; private set => Set(ref _CurrentViewModel, value); }
        #endregion

        #endregion

        #region Commands

        #region ShowDashboardViewCommand
        private ICommand? _ShowDashboardViewCommand;

        /// <summary>
        /// Show Dashboard View
        /// </summary>
        public ICommand? ShowDashboardViewCommand => _ShowDashboardViewCommand ??= new LambdaCommand(OnShowDashboardViewCommandExecuted, CanShowDashboardViewCommandnExecute);

        private bool CanShowDashboardViewCommandnExecute() => true;

        private void OnShowDashboardViewCommandExecuted()
        {
            CurrentViewModel = new DashboardViewModel(_transactionsRepository);
        }
        #endregion

        #region ShowBooksViewCommand
        private ICommand? _ShowBooksViewCommand;

        /// <summary>
        /// Show BooksView
        /// </summary>
        public ICommand? ShowBooksViewCommand => _ShowBooksViewCommand ??= new LambdaCommand(OnShowBooksViewCommandExecuted, CanShowBooksViewCommandnExecute);

        private bool CanShowBooksViewCommandnExecute() => true;

        private void OnShowBooksViewCommandExecuted()
        {
            CurrentViewModel = new BooksViewModel(_booksRepository, _categoriesRepository, _dialogService);
        }
        #endregion

        #region ShowSellersViewCommand
        private ICommand? _ShowSellersViewCommand;

        /// <summary>
        /// Show SellersView
        /// </summary>
        public ICommand? ShowSellersViewCommand => _ShowSellersViewCommand ??= new LambdaCommand(OnShowSellersViewCommandExecuted, CanShowSellersViewCommandnExecute);

        private bool CanShowSellersViewCommandnExecute() => true;

        private void OnShowSellersViewCommandExecuted()
        {
            CurrentViewModel = new SellersViewModel(_sellersRepository, _dialogService);
        }
        #endregion

        #region ShowBuyersViewCommand
        private ICommand? _ShowBuyersViewCommand;

        /// <summary>
        /// Show BuyersView
        /// </summary>
        public ICommand? ShowBuyersViewCommand => _ShowBuyersViewCommand ??= new LambdaCommand(OnShowBuyersViewCommandExecuted, CanShowBuyersViewCommandnExecute);

        private bool CanShowBuyersViewCommandnExecute() => true;

        private void OnShowBuyersViewCommandExecuted()
        {
            CurrentViewModel = new BuyersViewModel(_buyersRepository, _dialogService);
        }
        #endregion

        #region ShowTransactionsViewCommand
        private ICommand? _ShowTransactionsViewCommand;

        /// <summary>
        /// Show TransactionsView
        /// </summary>
        public ICommand? ShowTransactionsViewCommand => _ShowTransactionsViewCommand ??= new LambdaCommand(OnShowTransactionsViewCommandExecuted, CanShowTransactionsViewCommandnExecute);

        private bool CanShowTransactionsViewCommandnExecute() => true;

        private void OnShowTransactionsViewCommandExecuted()
        {
            CurrentViewModel = new TransactionsViewModel(
                _transactionsRepository, 
                _booksRepository, 
                _sellersRepository, 
                _buyersRepository, 
                _dialogService);
        }
        #endregion

        #region ShowStatisticViewCommand
        private ICommand? _ShowStatisticViewCommand;

        /// <summary>
        /// Show StatisticView
        /// </summary>
        public ICommand? ShowStatisticViewCommand => _ShowStatisticViewCommand ??= new LambdaCommand(OnShowStatisticViewCommandExecuted, CanShowStatisticViewCommandnExecute);

        private bool CanShowStatisticViewCommandnExecute() => true;

        private void OnShowStatisticViewCommandExecuted()
        {
            CurrentViewModel = new StatisticViewModel(_booksRepository, _categoriesRepository, _sellersRepository, _buyersRepository, _transactionsRepository);
        }
        #endregion

        #endregion

        public MainWindowViewModel(
            IRepository<Product> booksRepository, 
            IRepository<Category> categoriesRepository,
            IRepository<Employee> sellersRepository, 
            IRepository<Customer> buyersRepository,
            IRepository<Order> transactionsRepository,
            ITradingService tradingService,
            IUserDialogService dialogService)
        {
            _booksRepository = booksRepository;
            _categoriesRepository = categoriesRepository;
            _sellersRepository = sellersRepository;
            _buyersRepository = buyersRepository;
            _transactionsRepository = transactionsRepository;
            _tradingService = tradingService;
            _dialogService = dialogService;
        }

        //public async void TestTransactionAsync()
        //{
        //    var transactionsCount = _tradingService.Transactions?.Count();

        //    var book = await _booksRepository.GetAsync(5);
        //    var seller = await _sellersRepository.GetAsync(3);
        //    var buyer = await _buyersRepository.GetAsync(7);

        //    if (book is null || book.Name is null || seller is null || buyer is null) return;

        //    var transact = await _tradingService.CrateTransactionAsync(book.Name, seller, buyer, 235m);

        //    var transactionsCount2 = _tradingService.Transactions?.Count();
        //}
    }       
}
