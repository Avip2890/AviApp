using AviApp.Models;
using MediatR;
using AviApp.Results;

namespace AviApp.Api.Order.OrderQueries;
public record GetAllOrdersQuery() : IRequest<Result<List<OrderDto>>>;