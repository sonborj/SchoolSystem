using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Features.Students.Commands.CreateStudent;
using SchoolSystem.Application.Features.Students.Commands.DeleteStudent;
using SchoolSystem.Application.Features.Students.Commands.UpdateStudent;
using SchoolSystem.Application.Features.Students.DTOs;
using SchoolSystem.Application.Features.Students.Queries.GetAllStudents;
using SchoolSystem.Application.Features.Students.Queries.GetStudentById;

namespace SchoolSystem.WebAPI.Controllers;

public class StudentsController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<StudentDto>>> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllStudentsQuery()));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StudentDto>> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetStudentByIdQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create([FromBody] CreateStudentDto dto)
    {
        var id = await Mediator.Send(new CreateStudentCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentDto dto)
    {
        await Mediator.Send(new UpdateStudentCommand(id, dto));
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteStudentCommand(id));
        return NoContent();
    }
}
