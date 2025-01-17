using AviApp.Interfaces;
using AviApp.Models;
using AviApp.Mappers;
using AviApp.Results;
using MediatR;

namespace AviApp.Api.MenuItem.UpdateMenuItem;

public class UpdateMenuItemHandler(IMenuItemService menuItemService)
    : IRequestHandler<UpdateMenuItemCommand, Result<MenuItemDto>>
{
    public async Task<Result<MenuItemDto>> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItemEntity = request.MenuItemDto.ToEntity();
        menuItemEntity.Id = request.Id;

        var result = await menuItemService.UpdateMenuItemAsync(request.Id, menuItemEntity, cancellationToken);

        if (!result.IsSuccess)
        {
            return Result<MenuItemDto>.Failure(result.Error);
        }

        return Result<MenuItemDto>.Success(result.Value.ToDto());
    }
}