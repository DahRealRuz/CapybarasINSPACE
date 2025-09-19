public interface IPlayerMovement
{
    /*
    Interface method for handling player movement, the reason I made this interface is because I (currently) have 2 versions of player movement
    that being the platformer movement and the zero-g movement for the flying state.
    */
    public void HandleMovement(float delta); 
}