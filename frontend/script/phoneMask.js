const formatNumber = (phone) => {
  const onlyNumbers = phone.replace(/\D/g, '');
  const numberWithParenteses = onlyNumbers.replace(/^(\d{2})(\d)/g, '($1) $2');
  const numberWithHifen = numberWithParenteses.replace(/(\d)(\d{4})$/, '$1-$2');
  return numberWithHifen;
}

function executeMask(phone, adjustedPhone){ 
  phone.value = adjustedPhone;
}

export { formatNumber, executeMask };