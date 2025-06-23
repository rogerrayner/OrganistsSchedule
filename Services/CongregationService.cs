// ...existing code...
public async Task SetOrganistsAsync(int congregationId, List<int> congregationOrganists)
{
    // Remove todas as organistas vinculadas à congregação
    var existingOrganists = _context.CongregationOrganists
        .Where(co => co.CongregationId == congregationId);
    _context.CongregationOrganists.RemoveRange(existingOrganists);

    // Adiciona apenas as organistas recebidas na lista
    foreach (var organistId in congregationOrganists)
    {
        _context.CongregationOrganists.Add(new CongregationOrganist
        {
            CongregationId = congregationId,
            OrganistId = organistId
        });
    }

    await _context.SaveChangesAsync();
}
// ...existing code...
