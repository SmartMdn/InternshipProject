﻿using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.BLL.Services;

public class BuyTicketService : IBuyTicketService
{
    public BuyTicketService(IUnitOfWork database)
    {
        Database = database;
    }

    private IUnitOfWork Database { get; set; }
    public IEnumerable<TicketDTO> BuyTickets(List<int> ids)
    {
        List<Ticket> tickets;
        try
        {
            tickets = Database.Tickets.GetList(ids).ToList();
        }
        catch (NullReferenceException e)
        {
            return new List<TicketDTO>();
        }
        foreach (var variableTicket in tickets)
        {
            variableTicket.IsBought = true;
            Database.Tickets.Update(variableTicket);
        }
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
        Database.Save();
        return mapper.Map<IEnumerable<Ticket>,List<TicketDTO>>(tickets);
    }

    public TicketDTO BuyTicket(int? id)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Database.Dispose();
    }
}
