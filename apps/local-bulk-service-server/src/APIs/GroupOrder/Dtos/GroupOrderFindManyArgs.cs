using LocalBulkService.APIs.Common;
using LocalBulkService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocalBulkService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class GroupOrderFindManyArgs : FindManyInput<GroupOrder, GroupOrderWhereInput> { }
