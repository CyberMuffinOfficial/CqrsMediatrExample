﻿using CqrsMediatrExample.Entities;
using MediatR;

namespace CqrsMediatrExample.Commands;

public record AddProductCommand(Product Product) : IRequest;