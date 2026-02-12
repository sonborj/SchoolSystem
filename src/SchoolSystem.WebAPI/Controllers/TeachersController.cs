using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Features.Teachers.Commands.CreateTeacher;
using SchoolSystem.Application.Features.Teachers.Commands.DeleteTeacher;
using SchoolSystem.Application.Features.Teachers.Commands.UpdateTeacher;
using SchoolSystem.Application.Features.Teachers.DTOs;
using SchoolSystem.Application.Features.Teachers.Queries.GetAllTeachers;
using SchoolSystem.Application.Features.Teachers.Queries.GetTeacherById;

namespace SchoolSystem.WebAPI.Controllers;

public class TeachersController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<TeacherDto>>> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllTeachersQuery()));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TeacherDto>> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetTeacherByIdQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create([FromBody] CreateTeacherDto dto)
    {
        var id = await Mediator.Send(new CreateTeacherCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDto dto)
    {
        await Mediator.Send(new UpdateTeacherCommand(id, dto));
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTeacherCommand(id));
        return NoContent();
    }
}
