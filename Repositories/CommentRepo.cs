
using Microsoft.EntityFrameworkCore;

namespace api;

public class CommentRepo:ICommentRepo
{
    private readonly ApplicationDb _context;

    public CommentRepo(ApplicationDb context)
    {
        _context=context;
    }

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var commentModel=await _context.Comments.FirstOrDefaultAsync(obj=>obj.Id==id);
        if(commentModel==null){
            return null;
        }
        _context.Comments.Remove(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        var comments=await _context.Comments.ToListAsync();
        return comments;
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        var comment=await _context.Comments.FindAsync(id);
        return comment;
    }

    public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
    {
        var existingcomment=await _context.Comments.FindAsync(id);
        if(existingcomment==null){
            return null;
        }
        existingcomment.Title=commentModel.Title;
        existingcomment.Content=commentModel.Content;
        await _context.SaveChangesAsync();
        return existingcomment;
    }
}
