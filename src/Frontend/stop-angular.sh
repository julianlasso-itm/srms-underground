#!/bin/bash
trap 'kill $(jobs -p)' EXIT
npm start &
wait
