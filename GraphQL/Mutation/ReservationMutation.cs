﻿using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class ReservationMutation : ObjectGraphType
{
    public ReservationMutation(IReservation reservationService)
    {
        Field<ReservationType>("createReservation", arguments: new QueryArguments(new QueryArgument<ReservationInputType> { Name = "reservation" }),
            resolve: context => reservationService.AddReservation(context.GetArgument<Reservation>("reservation")));
    }
}
