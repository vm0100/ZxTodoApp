using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ZxTodoApp.Core;

namespace ZxTodoApp.ViewModels;

[ServiceDescriptor(typeof(MainViewModel))]
public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<string> _fixedStackSource = ["我的一天", "计划内", "全部", "任务"];
    [ObservableProperty] private ObservableCollection<string> _indefiniteStackSource = ["活动1", "活动2", "活动3", "活动4", "活动5", "活动6", "活动7"];
    [ObservableProperty] private string _selectStack = "我的一天";
}